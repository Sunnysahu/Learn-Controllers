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
    }
}