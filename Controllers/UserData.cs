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
    }
}
