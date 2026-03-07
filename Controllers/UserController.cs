using Learn_Controller.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Numerics;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learn_Controller.Controllers
{
    public class UserController : Controller
    {
        // Read Header Value -> https://localhost:7092/user/get-header-value/?headerName=User-Agent
        [Route("user/get-header-value")]
        public IActionResult GetHeaderValue(string headerName)
        {
            var userAgent = HttpContext.Request.Headers["user-agent"].ToString();
            return Content($"<h1>{userAgent}</h1>", "text/html");
        }

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

        [HttpPost]
        [Route("user/employee")]
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

        // Model Validation Example
        // Add [Required] and [EmailAddress] Data Annotations to Employee Model Properties and then hit this API -> https://localhost:7092/user/validate-email with body -> { "Name": "Sunny Sahu", "Email": "invalid-email" } ---> Body (raw)
        [HttpGet]
        [Route("validate-email")]
        public IActionResult ValidateEmail([FromBody] UserData userdata)
        {
            int ErrorCount = ModelState.ErrorCount;
            if (ModelState.IsValid)
            {
                return Ok(new
                {
                    ErrorCount = ErrorCount,
                    Message = "Validation Successful",
                    Name = userdata.Name,
                    Email = userdata.Email,
                    Age = userdata.Age,
                    Pincode = userdata.Pincode
                });
            }

            // Better Way

            return BadRequest(ModelState.SelectMany(
                entry => entry.Value.Errors.SelectMany(error => new Dictionary<string, string>
                {
                    {entry.Key.ToLower(), error.ErrorMessage }
                })));

            // Best Way

            //return BadRequest(
            //    ModelState
            //        .Where(x => x.Value != null && x.Value.Errors.Count > 0)
            //        .ToDictionary(
            //            x => x.Key.ToLower(),
            //            x => x.Value!.Errors.First().ErrorMessage
            //        )
            //);
            //return BadRequest(
            //    ModelState.Values
            //        .SelectMany(error => error.Errors)
            //        .Select(error => error.ErrorMessage)
            //);



            //More Data Annotations for Validation
            //[Required(ErrorMessage = "Field is required")] - Ensures a value is provided.

            //[EmailAddress(ErrorMessage = "Invalid email")] - Validates that the value is a valid email format.

            //[Range(1, 100, ErrorMessage = "Value must be between 1 and 100")] - Validates that a numeric value falls within a specified range.

            //[StringLength(50, MinimumLength = 5, ErrorMessage = "Length must be 5–50 characters")] - Validates string length with optional minimum and maximum limits.

            //[MaxLength(50, ErrorMessage = "Maximum 50 characters allowed")] - Ensures the value does not exceed the specified maximum length.

            //[MinLength(5, ErrorMessage = "Minimum 5 characters required")] - Ensures the value meets the specified minimum length.

            //[RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only letters and numbers allowed")] - Validates the value using a regular expression pattern.

            //[Compare("Password", ErrorMessage = "Passwords do not match")] - Ensures two properties have the same value.

            //[DataType(DataType.Date, ErrorMessage = "Invalid date")] - Specifies the expected data type for formatting and UI purposes.

            //[CreditCard(ErrorMessage = "Invalid credit card number")] - Validates that the value is in a valid credit card format.

            //[Phone(ErrorMessage = "Invalid phone number")] - Validates that the value is a valid phone number format.

            //[Url(ErrorMessage = "Invalid URL")] - Validates that the value is a valid URL.

            //[FileExtensions(Extensions = "jpg,png", ErrorMessage = "Only jpg and png allowed")] - Restricts file uploads to specified extensions.

            //[Display(Name = "Employee Name")] - Specifies a friendly display name for UI labels.

            //[Key] - Marks the property as the primary key in Entity Framework.

            //[ForeignKey("Department")] - Specifies the foreign key relationship with another entity.

            //[NotMapped] - Excludes the property from being mapped to a database column.[Required(ErrorMessage = "Field is required")] - Ensures a value is provided.

            //[EmailAddress(ErrorMessage = "Invalid email")] - Validates that the value is a valid email format.

            //[Range(1, 100, ErrorMessage = "Value must be between 1 and 100")] - Validates that a numeric value falls within a specified range.

            //[StringLength(50, MinimumLength = 5, ErrorMessage = "Length must be 5–50 characters")] - Validates string length with optional minimum and maximum limits.

            //[MaxLength(50, ErrorMessage = "Maximum 50 characters allowed")] - Ensures the value does not exceed the specified maximum length.

            //[MinLength(5, ErrorMessage = "Minimum 5 characters required")] - Ensures the value meets the specified minimum length.

            //[RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only letters and numbers allowed")] - Validates the value using a regular expression pattern.

            //[Compare("Password", ErrorMessage = "Passwords do not match")] - Ensures two properties have the same value.

            //[DataType(DataType.Date, ErrorMessage = "Invalid date")] - Specifies the expected data type for formatting and UI purposes.

            //[CreditCard(ErrorMessage = "Invalid credit card number")] - Validates that the value is in a valid credit card format.

            //[Phone(ErrorMessage = "Invalid phone number")] - Validates that the value is a valid phone number format.

            //[Url(ErrorMessage = "Invalid URL")] - Validates that the value is a valid URL.

            //[FileExtensions(Extensions = "jpg,png", ErrorMessage = "Only jpg and png allowed")] - Restricts file uploads to specified extensions.

            //[Display(Name = "Employee Name")] - Specifies a friendly display name for UI labels.

            //[Key] - Marks the property as the primary key in Entity Framework.

            //[ForeignKey("Department")] - Specifies the foreign key relationship with another entity.

            //[NotMapped] - Excludes the property from being mapped to a database column.
        }
    }
}