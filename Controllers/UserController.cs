using Microsoft.AspNetCore.Mvc;

namespace Learn_Controller.Controllers
{
    public class UserController : Controller
    {
        [Route("user/register")]
        public IActionResult Register(string username, string email)
        {
            if (!string.IsNullOrEmpty(username) && username.Length >= 5)
            {
                return RedirectToAction("About", "Home", new { });
            }
            return RedirectToAction("Index", "Home", new { });
        }
    }
}