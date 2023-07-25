using System.ComponentModel.DataAnnotations;

namespace LMS.Models.EmployeeModel
{
    public class Employee
    {
        
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Name cannot be blank")]
        public string Emp_Name { get; set; }
        [Required(ErrorMessage = "CreatedBy cannot be blank")]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage = "ModifiedBy cannot be blank")]
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Required(ErrorMessage = "IsActive cannot be blank")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Username cannot be blank")]
        public string Username { get; set; }

    }
}
