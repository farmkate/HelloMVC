using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    //[EvilTrackingCookie]
    public class HelloController : Controller
    {
        // GET: /<controller>/

        [HttpGet]
        public IActionResult Index() //could provide default method to replace the if statement -- public IActionResult Index(string name = "World")
        {
            //string html = "<form method='post' action='/Hello/Display'>" + "<input type='text' name='name' />" + "<input type='submit' value='Greet me!' />" + "</form>";
            // instead of explicitly saying action, you can add a route handler
            string html = "<form method='post' >" + "<input type='text' name='name' />" + 
                "<select name='language'>" + 
                "<option value = 'French'>French</option><option value = 'Spanish' > Spanish </ option ><option value = 'German' > German </ option ><option value = 'Italian' > Italian </ option ><option value = 'Russian' > Russian </ option ></select>" +
                "<input type='submit' value='Greet me!' />" + "</form>";
            //if (string.IsNullOrEmpty(name)) //could provide default method if (string.IsNullOrEmpty(string name = "World")
            //{
            //    name = "World";
            //}
            return Content(html, "text/html");
           // return Redirect("/Hello/Goodbye");
        }

        //[Route("/Hello")]
        //[HttpPost]
        public static string CreateMessage(string name = "World", string language = "English")
        {
            Dictionary<string, string> languageDict = new Dictionary<string, string>()
            {
                {"English", "Hello" }, { "French", "Bonjour"}, {"Spanish", "Adios" }, {"German", "Guten Tag" }, {"Italian", "Ciao" }, {"Russian", "Allo" }
            };

            string intro = languageDict[language];
            return (string.Format("<h1>{0} {1}</h1>", intro, name));

        }

        [Route("/Hello")]
        [HttpPost]
        //[EvilTrackingCookie]
        public IActionResult Display(string name = "World", string language = "English")
        {
            return Content(CreateMessage(name, language), "text/html");

        }

        // Handle requests to /Hello/NAME -- (NAME is a url segment)
        //[Route("/Hello/{name}")]
        //public IActionResult Index2(string name)
        //{
        //    return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        //}

        // /Hello/Goodbye
        // alter th eroute to this controller to be: /Hello/Aloha
        // [Route("/Hello/Aloha")]
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }
}
