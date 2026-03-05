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
                new VirtualFileResult("My Resume Final.pdf", MediaTypeNames.Application.Pdf);
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

        [HttpGet]
        [Route("download-docx-file-without-saving")]
        public FileResult DownloadDocxFileUsingByte()
        {
            // This method is used to send a file to the browser without saving it on the server. It is useful when you want to generate a file on the fly and send it to the user without saving it on the server. `FileContentResult` needs the file content as a byte array.

            byte[] fileBytes = System.IO.File.ReadAllBytes(@"D:\source\repos\Learn Controller\wwwroot\Users.docx");
            return File(fileBytes, MediaTypeNames.Application.Octet, "User.docx");
        }

        [HttpGet]
        [Route("download-large-file-with-buffering")]
        public FileResult DownloadLargeFileWithBuffering()
        {
            var stream = new FileStream(@"D:\source\repos\Learn Controller\wwwroot\Users.docx", FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 8192, FileOptions.Asynchronous | FileOptions.SequentialScan);
            return File(stream, MediaTypeNames.Application.Octet, "UserWord.docx");

            // FileMode -> tells the system what to do with the file when you open it.
            // CreateNew : Creates a new file. If the file already exists, an IOException is thrown.
            // Create : Creates a new file. If the file already exists, it is overwritten.
            // Open : Opens an existing file. If the file does not exist, a FileNotFoundException is thrown.
            // OpenOrCreate : Opens a file if it exists; otherwise, a new file is created.
            // Append : Opens a file for writing at the end. Creates the file if it doesn’t exist.
            // Truncate : Opens an existing file and truncates its size to zero bytes. If the file does not exist, a FileNotFoundException is thrown.

            // FileAccess -> controls how you can use the file: read, write, or both.
            // Read : Allows you to read from the file. You cannot write to the file.
            // Write : Allows you to write to the file. You cannot read from the file.
            // ReadWrite : Allows you to read from and write to the file.

            // FileShare -> controls how other processes can access the file while it is open.
            // None : No other process can access the file while it is open.
            // Read : Other processes can read the file while it is open, but they cannot write to it.
            // Write : Other processes can write to the file while it is open, but they cannot read from it.
            // ReadWrite : Other processes can read from and write to the file while it is open.
            // Delete : Other processes can delete the file while it is open, but they cannot read from or write to it.
            // Inheritable : Other processes can inherit the file handle, allowing them to access the file while it is open.

            // FileOptions -> provides additional options for how the file is accessed and used.
            // None : Indicates that no special options are specified for file access. This is the default value if no options are provided.
            // Asynchronous : Indicates that the file is being accessed asynchronously, allowing for non-blocking I/O operations.
            // DeleteOnClose : Indicates that the file should be automatically deleted when it is closed.
            // SequentialScan : Indicates that the file will be accessed sequentially, which can optimize performance for certain types of file access patterns.
            // RandomAccess : Indicates that the file will be accessed randomly, which can optimize performance for certain types of file access patterns.
            // Encrypted : Indicates that the file is encrypted and should be decrypted when accessed.
            // WriteThrough : Indicates that the file should be written through to the underlying storage, bypassing any intermediate caching mechanisms. This can be useful for ensuring data integrity in certain scenarios, such as when writing critical data that must be immediately persisted to disk.
        }



        [HttpGet]
        [Route("download-action-pdf-file")]
        public ActionResult ActionDownloadPdf()
        {
            return File("My Resume Final.pdf", MediaTypeNames.Application.Pdf, "Resume.pdf");
        }

        private static int i = 0;

        [HttpGet]
        [Route("download-iaction-json-data")]
        public IActionResult IActionJsonData()
        {
            AboutMe aboutMe = new AboutMe()
            {
                Id = Guid.NewGuid(),
                Name = "Sunny",
                Email = $"{++i} Sunny@gmail.com"
            };
            return Json(aboutMe);
        }

        // Hit This -> https://localhost:7092/get-user/102
        // FromRoute
        [HttpGet]
        [Route("get-user/{id}")]
        public string GetUserById([FromRoute] int id)
        {
            return $"User with ID {id} retrieved successfully.";
        }


        // Hit This ->  https://localhost:7092/search-users/?name=Sunny Sahu&age=26
        // FromQuery
        [HttpGet]
        [Route("search-users/{name?}/{age?}")]
        public string SearchUsers([FromQuery] string name, [FromQuery] int age)
        {
            return $"Searching for users with Name: {name} and Age: {age}";
        }


        // Without using FromQuery
        [HttpGet]
        [Route("withoutfromquery")]
        public IActionResult WithoutFromQuery()
        {
            string name = Request.Query["name"].ToString();
            if (string.IsNullOrEmpty(name)) name = "User Not Found...";

            return Content($"You Name is {name}");
        }

        // Hit this -> https://localhost:7092/create-user/?name=Sunny-Sahu&email=sunny@gmail.com
        [HttpGet]
        [Route("create-user")]
        public string CreateUser([FromQuery] AboutMe user)
        {
            string age =  Request.Query["age"].ToString(); // This is how you can access the query parameter without using [FromQuery] attribute. You can also use Request.Form, Request.Headers, Request.Cookies, etc. to access the data from the request.

            return $"User {user.Name} with Email {user.Email} created successfully.";

        }


        // FromForm, FromHeader, FromServices
    }
}