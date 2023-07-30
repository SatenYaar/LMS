using LMS.Models.EmployeesModels;

namespace LMS.Models.ViewModel
{
    public class EmpViewModelData
    {
        public EmpModel Employee { get; set; }
        public List<EmpModel> Employeeslist { get; set; }
        public LeavesModel Leaves { get; set; }
        public List<LeavesModel>Leaveslist { get; set; }
    }
}
