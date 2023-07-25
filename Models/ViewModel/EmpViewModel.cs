using LMS.Models.EmployeeModel;

namespace LMS.Models.ViewModel
{
    public class EmpViewModel
    {
        // Represents a single employee object.
        public EmployeeModel.EmployeeModel Employee { get; set; }

        // Represents a collection of Employee objects.
        public IEnumerable<EmployeeModel.EmployeeModel> EmployeesList { get; set; }

        // Represents a single leaves object.
        public LeavesModel Leaves { get; set; }

        // Represents a collection of Leaves objects.
        public IEnumerable<LeavesModel> LeavesList { get; set; }

        public EmpViewModel()
        {
            // Initialize the collections to avoid null reference exceptions.
            EmployeesList = new List<EmployeeModel.EmployeeModel>();
            LeavesList = new List<LeavesModel>();
        }
    }

}
