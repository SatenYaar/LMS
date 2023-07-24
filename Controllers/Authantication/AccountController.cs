using Google.Apis.Admin.Directory.directory_v1.Data;
using LMS.Models.EmployeeModel;
using LMS.Models.ViewModel;
using LMS.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web;

namespace LMS.Controllers.Authantication
{
    public class AccountController : Controller
    {

        public readonly IConfiguration _configuration;

        private readonly IAPTService _apiservice;
        public static string? sBU;
        public static string? sUserCode;

        public AccountController(IConfiguration configuration, IAPTService service)
        {
            this._configuration = configuration;
            this._apiservice = service;
        }

        public string GetBaseUrl()
        {
            string sBaseUrl = _configuration.GetSection("appsetting")["Baseurl"].ToString();
            sBU = sBaseUrl;
            return sBaseUrl;
        }


        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel signUp)
        {
            if (ModelState.IsValid)
            {
                GetBaseUrl();
                sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
                if (string.IsNullOrEmpty(sUserCode))
                {
                    sUserCode = "123456";
                }
                string mess = string.Empty;
                string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode;
                string sBaseUrl = sBU + "api/Account/CreateUser";
                APIResponse response = await _apiservice.SignUpPostAPI(sBaseUrl, sTokenUrl, signUp);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    mess = response.Result;
                    TempData["result"] = mess;
                    // return RedirectToAction("Login"); // Redirect to the login page to show the success message
                    return View();
                }
                else
                {
                    TempData["error"] = "An error occurred during signup.";
                    return View();
                }
            }
            else
            {
                TempData["error"] = "An error occurred during signup.";
                // If the model state is invalid, return to the signup page with error messages.
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        LoginModel data = new LoginModel();

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                GetBaseUrl();
                sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
                if (string.IsNullOrEmpty(sUserCode))
                {
                    sUserCode = "123456";
                }

                string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode;
                string sBaseUrl = sBU + "api/Account/LoginUser";
                APIResponse response = await _apiservice.LoginPostAPI(sBaseUrl, sTokenUrl, login);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    data = JsonConvert.DeserializeObject<LoginModel>(response.Result);
                    if (data != null && data.Username == login.Username && data.Password == login.Password)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, login.Username) },
                                   CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        // Since you have stored the username in the session, you can remove this line:
                        HttpContext.Session.SetString("Username", login.Username);

                        TempData["SuccessMessage"] = "Login successfully.";
                        return View();
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Invalid username or password.";
                        return View(login);
                    }
                }
                else
                {
                    // Handle the error response from the API appropriately
                    TempData["ErrorMessage"] = "An error occurred during login.";
                    return View(login);
                }
            }
            else
            {
                // Model state is not valid, return the view with the login model to display validation errors.
                return View(login);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedcookies = Request.Cookies.Keys;
            foreach (var cookie in storedcookies)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login", "Account");

        }

    }
}
