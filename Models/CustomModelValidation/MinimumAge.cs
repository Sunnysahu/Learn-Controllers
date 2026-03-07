using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Learn_Controller.Models.CustomModelValidation
{
    public class MinimumAge : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAge(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date of Birth is required");

            }

            DateTime date = (DateTime) value;
            int age = DateTime.Now.Year - date.Year; // Calculate age based on the year difference

            if (date > DateTime.Now.AddYears(-age))
            {
                age--; // Adjust age if the birthday hasn't occurred yet this year
            }
            if (age < _minimumAge)
            {
                return new ValidationResult(ErrorMessage ?? $"Minimum age is {_minimumAge} years");
            }

            return ValidationResult.Success;
        }
    }
}