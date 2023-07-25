using LMS.Models.EmployeeModel;

namespace LMS.Models.ViewModel
{
    public class EmpViewModel
    {
        // Represents a single employee object.
        public Employee Employee { get; set; }

        // Represents a collection of Employee objects.
        public IEnumerable<Employee> EmployeesList { get; set; }

        // Represents a single leaves object.
        public Leaves Leaves { get; set; }

        // Represents a collection of Leaves objects.
        public IEnumerable<Leaves> LeavesList { get; set; }

        public EmpViewModel()
        {
            // Initialize the collections to avoid null reference exceptions.
            EmployeesList = new List<Employee>();
            LeavesList = new List<Leaves>();
        }
    }

}
