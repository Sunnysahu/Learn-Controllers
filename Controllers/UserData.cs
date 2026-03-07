using Learn_Controller.Models.CustomModelValidation;
using System.ComponentModel.DataAnnotations;

namespace Learn_Controller.Controllers
{
    public class UserData
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]

        public required string Email { get; set; }

        [Range(18,65, ErrorMessage = "Age must be between 18 and 65")]
        public int Age { get; set; }

        [Range(100000, 999999, ErrorMessage = "Pincode must be a 6-digit number")]
        public int Pincode { get; set; }

        // Custom Validation Example - Create a custom validation attribute to validate that the name does not contain any digits.
        // Create a Folder inside Models and create a folder and then create a class MinimumAgeAttribute.cs and then add the code. Inherit from `ValidationAttribute` and override the IsValid method to implement the custom validation logic. Then use this custom validation attribute on the DateOfBirth property in the UserData model. Finally, hit the API with a date of birth that does not meet the minimum age requirement to see the validation in action.

        [Required]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }
    }
}
