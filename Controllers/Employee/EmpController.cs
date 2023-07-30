
using LMS.Models.EmployeesModels;
using LMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;

namespace LMS.Controllers.Employee
{
    [Authorize]
    public class EmpController : Controller
    {

        public readonly IConfiguration _configuration;

        private readonly IAPTService _apiservice;
        public static string? sBU;
        public static string? sUserCode;

        public static List<EmpModel> Employees { get; set; }
        public EmpController(IConfiguration configuration, IAPTService apiservice)
        {
            _configuration = configuration;
            _apiservice = apiservice;
        }

        public string GetBaseUrl()
        {
            string sBaseUrl = _configuration.GetSection("appsetting")["Baseurl"].ToString();
            sBU = sBaseUrl;
            return sBaseUrl;
        }

        public async Task<IActionResult> Index()
        {
            string sBaseUrl = string.Empty;
            ViewBag.UserName = User.Identity.Name;
            var usertype = ViewBag.UserName;
            GetBaseUrl();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            if (usertype == "Admin")
            {
                sBaseUrl = sBU + "api/Employee/GetAllEmployee?";
            }
            else
            {

                sBaseUrl = sBU + "api/Employee/GetAllEmployee?&Username=" + usertype + "";
            }
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Employees = JsonConvert.DeserializeObject<List<EmpModel>>(response.Result);
                return View("Index", Employees);

            }
            else
            {
                return View();

            }
        }
        // [AllowAnonymous]
        public IActionResult Create()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmpModel emp)
        {

            GetBaseUrl();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string mess = string.Empty;
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/CreateEmployee?";
            APIResponse response = await _apiservice.PostAPI(sBaseUrl, sTokenUrl, emp);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                mess = response.Result;
                HttpContext.Session.SetString("ToastMessage", mess);
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetString("ToastMessage", "Employee Cration failed. Please check your credentials.");
                HttpContext.Session.SetString("ToastType", "error");
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GetBaseUrl();
            EmpModel employee = new EmpModel();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/GetEmployeeById?&iEmpId=" + id + "";
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                employee = JsonConvert.DeserializeObject<EmpModel>(response.Result);
                return View(employee);

            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmpModel emp)
        {
            GetBaseUrl();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string mess = string.Empty;
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/UpdateEmployee?";
            APIResponse response = await _apiservice.PutAPI(sBaseUrl, sTokenUrl, emp);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                mess = response.Result;

                HttpContext.Session.SetString("ToastMessage", mess);
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetString("ToastMessage", "Employee Updation failed. Please check your credentials.");
                HttpContext.Session.SetString("ToastType", "error");
                return View();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            GetBaseUrl();
            EmpModel employee = new EmpModel();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/GetEmployeeById?&iEmpId=" + id + "";
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                employee = JsonConvert.DeserializeObject<EmpModel>(response.Result);
                return View(employee);

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            GetBaseUrl();
            EmpModel employee = new EmpModel();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/GetEmployeeById?&iEmpId=" + id + "";
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                employee = JsonConvert.DeserializeObject<EmpModel>(response.Result);
                return View(employee);

            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, string data)
        {
            GetBaseUrl();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string mess = string.Empty;
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/DeleteEmployeeById?&iEmpId=" + id + "";
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                mess = response.Result;
                HttpContext.Session.SetString("ToastMessage", mess);
                return View("Index", Employees);
            }
            else
            {
                HttpContext.Session.SetString("ToastMessage", "Employee Cration failed. Please check your credentials.");
                HttpContext.Session.SetString("ToastType", "error");
                return View();

            }
        }

    }
}
