using LMS.Models.EmployeesModels;
using LMS.Models.ViewModel;
using LMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;

namespace LMS.Controllers.Employee
{
    [Authorize]
    public class LeavesController : Controller
    {

        public readonly IConfiguration _configuration;

        private readonly IAPTService _apiservice;
        public static string? sBU;
        public static string? sUserCode;

        public LeavesController(IConfiguration configuration,IAPTService service)
        {
            _configuration = configuration;
            _apiservice = service;
        }
        public string GetBaseUrl()
        {
            string sBaseUrl = _configuration.GetSection("appsetting")["Baseurl"].ToString();
            sBU = sBaseUrl;
            return sBaseUrl;
        }
        public static List<LeavesModel>leave = new List<LeavesModel>();
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
                sBaseUrl = sBU + "api/Leaves/GetAllLeaves?";
            }
            else
            {

                sBaseUrl = sBU + "api/Leaves/GetAllLeaves?&Username=" + usertype + "";
            }
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                leave = JsonConvert.DeserializeObject<List<LeavesModel>>(response.Result);

            }
            return View("Index", leave);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? LeaveId)
        {
            ViewBag.UserName = User.Identity.Name;
            LeavesModel viewModelData = new LeavesModel();

            if (LeaveId == null)
            {
 
                return View(viewModelData);
            }
            else
            {
                GetBaseUrl();
                sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
                if (string.IsNullOrEmpty(sUserCode))
                {
                    sUserCode = "123456";

                }
                string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
                string sBaseUrl = sBU + "api/Leaves/GetLeavesById?&iLeaveId=" + LeaveId + "";
                APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    viewModelData = JsonConvert.DeserializeObject<LeavesModel>(response.Result);

                }
            }

            return View(viewModelData);
        }

        [HttpPost]
        public async Task<IActionResult>CreateUpdate(LeavesModel viewModelData)
        {
            if (ModelState.IsValid)
            {
                if (viewModelData.LeaveId == 0)
                {
                    GetBaseUrl();
                    sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
                    if (string.IsNullOrEmpty(sUserCode))
                    {
                        sUserCode = "123456";

                    }
                    string mess = string.Empty;
                    string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
                    string sBaseUrl = sBU + "api/Leaves/CreateLeave?";
                    APIResponse response = await _apiservice.LeavePostAPI(sBaseUrl, sTokenUrl, viewModelData);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        mess = response.Result;
                        ViewData["result"] = mess;
                    }
                }
                else
                {
                    GetBaseUrl();
                    sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
                    if (string.IsNullOrEmpty(sUserCode))
                    {
                        sUserCode = "123456";

                    }
                    string mess = string.Empty;
                    string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
                    string sBaseUrl = sBU + "api/Leaves/UpdateLeave?";
                    APIResponse response = await _apiservice.LeavePostAPI(sBaseUrl, sTokenUrl, viewModelData);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        mess = response.Result;
                        ViewData["result"] = mess;
                    }
                }

                return RedirectToAction("Index");
            }

            return View(viewModelData);
        }



    }
}
