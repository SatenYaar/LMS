namespace LMS.Models.EmployeeModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LeavesModel
    {
        public int LeaveId { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "From date is required.")]
        [FutureDate(ErrorMessage = "From date should be a future date.")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Up to date is required.")]
        [FutureDate(ErrorMessage = "Up to date should be a future date.")]
        [DateAfter("FromDate", ErrorMessage = "Up to date should be after From date.")]
        public DateTime UpToDate { get; set; }

        [Required(ErrorMessage = "Leaves type is required.")]
        public string LeavesType { get; set; }

        [Required(ErrorMessage = "Approved by is required.")]
        public string ApprovedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        public bool Validate()
        {
            var validationContext = new ValidationContext(this, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            // Validate using data annotations
            bool isValid = Validator.TryValidateObject(this, validationContext, validationResults, true);

            return isValid;
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date > DateTime.Now;
        }
    }

    public class DateAfterAttribute : ValidationAttribute
    {
        private readonly string _dateToCompare;

        public DateAfterAttribute(string dateToCompare)
        {
            _dateToCompare = dateToCompare;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            DateTime dateToCompare = (DateTime)validationContext.ObjectType.GetProperty(_dateToCompare).GetValue(validationContext.ObjectInstance);

            if (date > dateToCompare)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }

}
