using Learn_Controller.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learn_Controller.Controllers
{
    public class UserController : Controller
    {
        // Hit This -> https://localhost:7092/user/register/?username=SunnySahu&email=Sunnysahu@gmail.com
        [Route("user/register")]
        public IActionResult Register(string username, string email)
        {
            if (!string.IsNullOrEmpty(username) && username.Length >= 5)
            {
                return RedirectToAction("About", "Home", new { });
            }
            return RedirectToAction("Index", "Home", new { });
            /*
            Success Responses
                Ok()              → 200 OK
                Ok(object)        → 200 + data
                Created()         → 201 Created
                CreatedAtAction() → 201 with action route
                CreatedAtRoute()  → 201 with route
                NoContent()       → 204 No Content

            Redirect Results
                Permanent redirects (301)
                    RedirectPermanent("/about-us")
                    RedirectToActionPermanent("Index","Home")
                    RedirectToRoutePermanent("routeName")
                    LocalRedirectPermanent("/home")

                Temporary redirects (302)
                    Redirect("/about-us")
                    RedirectToAction("Index","Home")
                    RedirectToRoute("routeName")
                    LocalRedirect("/home")

            Client Error Responses
                BadRequest()              → 400
                BadRequest(object)
                Unauthorized()            → 401
                Forbid()                  → 403
                NotFound()                → 404
                Conflict()                → 409
                UnprocessableEntity()     → 422

            Server Error Responses
                StatusCode(500)
                Problem()
            */
        }

        // Read Header Value -> https://localhost:7092/user/get-header-value/?headerName=User-Agent
        [Route("user/get-header-value")]
        public IActionResult GetHeaderValue(string headerName)
        {
            var userAgent = HttpContext.Request.Headers["user-agent"].ToString();
            return Content($"<h1>{userAgent}</h1>", "text/html");
        }

        [HttpPost]
        [Route("user/employee")]
        // Hit This (Browser Only) -> https://localhost:7092/user/employee?name=SunnySahu&Email=SunnySahu@gmail.com
        public IActionResult RegisterEmployee([FromBody] Employee employee) 
        {
            //return Ok($"The Employee Name is {employee.Name} and Employee Email is {employee.Email}");
            return Ok(new
            {
                Message = "Employee Registered Successfully",
                Name = employee.Name,
                Email = employee.Email
            });
        }
    }
}