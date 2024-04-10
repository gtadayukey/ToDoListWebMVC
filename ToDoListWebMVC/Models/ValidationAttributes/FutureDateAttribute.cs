using System.ComponentModel.DataAnnotations;

namespace ToDoListWebMVC.Models.ValidationAttributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public FutureDateAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not DateOnly date)
            {
                return new ValidationResult("Invalid date type.");
            }

            var currentDate = DateOnly.FromDateTime(DateTime.Today);

            if (date < currentDate)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be a future date.");
            }

            return ValidationResult.Success;
        }
    }
}
