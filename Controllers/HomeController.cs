using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Learn_Controller.Controllers
{
    public class HomeController : Controller
    {
        [Route("about-us")]
        public string About()
        {
            return "This is About Page";
        }

        [Route("contact-us")]
        public string Contact()
        {
            return "This is Contact Us Page";
        }

        [Route("home")]
        public string Index()
        {
            return "Hello Sunny";
        }
        [Route("text-content")]
        public ContentResult TextContent()
        {
            return new ContentResult()
            {
                Content = "Hello Sunny, I'm From TextContent",
                ContentType = "text/plain"
            };
        }
        [Route("html-content")]
        public ContentResult HtmlContent()
        {
            return new ContentResult()
            {
                Content = "<h1>Hello Sunny, I'm from <span style=color:red>HTML</span> Content</h1>",
                ContentType = MediaTypeNames.Text.Html
            };
        }

        [Route("json-content")]
        public JsonResult JsonContent()
        {
            var data = new
            {
                Name = "Sunny",
                Age = 30,
                City = "New York",
                Address = new
                {
                    Street = "123 Main St",
                    ZipCode = "10001"
                },
                Hobbies = new[] { "Reading", "Traveling", "Coding" }
            };
            return new JsonResult(data);
        }

        [HttpGet]
        [Route("getname")]
        public string GetName()
        {
            return "Hi, My name is Sunny";
        }

        [HttpPost]
        [Route("setname")]
        public string SetName(string name)
        {
            return $"Named {name} saved in Database";
        }
    }
}