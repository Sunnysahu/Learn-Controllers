using Learn_Controller.Models;
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

        [Route("home/about")]
        public JsonResult Abouts()
        {
            AboutMe aboutme = new AboutMe()
            {
                Id = Guid.NewGuid(),
                Name = "Sunny",
                Email = "Sunny@gmail.com"
            };
            return Json(aboutme);
            //return new JsonResult(aboutme);
        }

        // Sending File
        [HttpGet]
        [Route("download-pdf-file")]
        public FileResult DownloadVirtualPdfFile()
        {
            // VirtualFileResult is used to send a file directly to the browser and open it without downloading it. It is used when you want to display the file in the browser instead of prompting the user to download it.
            return 
                new VirtualFileResult("My Resume Final.pdf",MediaTypeNames.Application.Pdf); 
        }

        [HttpGet]
        [Route("download-pdf-physical-file")]
        public FileResult DownloadPhysicalTxtFile()
        {
            // PhysicalFileResult is used to send a file to the browser and prompt the user to download it. It is used when you want the user to download the file instead of displaying it in the browser. `PhysicalFileResult` needs the absolute file path on disk
            return new PhysicalFileResult(@"D:\source\repos\Learn Controller\wwwroot\3rd Highest.txt", MediaTypeNames.Text.Plain);
        }

        [HttpGet]
        [Route("download-jpg-file")]
        public FileResult DownloadJpgFile()
        {
            // FileContentResult is used to send a file to the browser and prompt the user to download it. It is used when you want the user to download the file instead of displaying it in the browser. 

            return File("Profile.jpg", MediaTypeNames.Image.Jpeg, "NewProfilePhoto.jpg");
        }
    }
}