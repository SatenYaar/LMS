using LMS.Models.EmployeeModel;
using LMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Web;

namespace LMS.Controllers.Employees
{
    [Authorize]
    public class EmployeesController : Controller
    {

        public readonly IConfiguration _configuration;

        private readonly IAPTService _apiservice;
        public static string? sBU;
        public static string? sUserCode;

        public static List<Employee> Employees { get; set; }
        public EmployeesController(IConfiguration configuration, IAPTService apiservice)
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
            GetBaseUrl();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/GetAllEmployee?";
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Employees = JsonConvert.DeserializeObject<List<Employee>>(response.Result);
            }
            return View("Index", Employees);
        }
       // [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
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
                ViewData["result"] = mess;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            GetBaseUrl();
            Employee employee=new Employee();
            sUserCode = Convert.ToString(HttpUtility.ParseQueryString(Request.QueryString.ToString()).Get("UId"));
            if (string.IsNullOrEmpty(sUserCode))
            {
                sUserCode = "123456";

            }
            string sTokenUrl = sBU + "GenerateToken" + "?sUsrCode=" + sUserCode + "";
            string sBaseUrl = sBU + "api/Employee/GetEmployeeById?&iEmpId="+id+"";
            APIResponse response = await _apiservice.CalAPI(sBaseUrl, sTokenUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                employee = JsonConvert.DeserializeObject<Employee>(response.Result);

            }
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee emp)
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
                ViewData["result"] = mess;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            GetBaseUrl();
            Employee employee = new Employee();
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
                employee = JsonConvert.DeserializeObject<Employee>(response.Result);

            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            GetBaseUrl();
            Employee employee = new Employee();
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
                employee = JsonConvert.DeserializeObject<Employee>(response.Result);

            }
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,string data)
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
                ViewData["delresult"] = mess;

            }
            return View("Index", Employees);
        }

    }
}
