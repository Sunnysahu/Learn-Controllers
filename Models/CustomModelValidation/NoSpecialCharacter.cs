using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Learn_Controller.Models.CustomModelValidation
{
    public class NoSpecialCharacter : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? str = value.ToString();

            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult("Name can't be Empty or Null");
            }

            if (!string.IsNullOrEmpty(str))
            {
                bool status = Regex.IsMatch(str, @"^[a-zA-Z]+$")
                    if (!status)
                    {
                        return new ValidationResult("Name should not contain special characters or digits");
                    }
            }

            return ValidationResult.Success;
        }
    }
}