
using LMS.Models.EmployeeModel;
using LMS.Models.ViewModel;
using LMS.Service;

namespace LMS.Service
{
    public interface IAPTService
    {
        public Task<APIResponse> CalAPI(string sUrl, string sTokenUrl);

        public Task<APIResponse> PostAPI(string sUrl, string sTokenUrl,EmployeeModel data);

        public Task<APIResponse> PutAPI(string sUrl, string sTokenUrl, EmployeeModel data);

        //SignUp
        public Task<APIResponse> SignUpPostAPI(string sUrl, string sTokenUrl, SignUpModel signUp);
        public Task<APIResponse> LoginPostAPI(string sUrl, string sTokenUrl, LoginModel login);

    }
}
