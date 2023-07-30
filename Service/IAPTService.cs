
using LMS.Models.EmployeesModels;
using LMS.Models.ViewModel;
using LMS.Service;

namespace LMS.Service
{
    public interface IAPTService
    {
        public Task<APIResponse> CalAPI(string sUrl, string sTokenUrl);
        public Task<APIResponse> PostAPI(string sUrl, string sTokenUrl,EmpModel data);
        public Task<APIResponse> PutAPI(string sUrl, string sTokenUrl, EmpModel data);

        //SignUp
        public Task<APIResponse> SignUpPostAPI(string sUrl, string sTokenUrl, SignUpModel signUp);
        public Task<APIResponse> LoginPostAPI(string sUrl, string sTokenUrl, LoginModel login);

        //leave
        public Task<APIResponse> LeavePostAPI(string sUrl, string sTokenUrl, LeavesModel viewModelData);

    }
}
