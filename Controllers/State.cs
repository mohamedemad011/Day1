using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Day1.Controllers
{
    public class State : Controller
    {

        public IActionResult SetCookie()
        {
            Response.Cookies.Append("Name", "Mo");
            return Content("Cookie Set !");
        }
        public IActionResult GetCookie()
        {
            string? userName = Request.Cookies["Name"];
            return Content($"Username : {userName}");
        }
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Mohamed");
            HttpContext.Session.SetInt32("Age", 30);
            return Content("Session Set !");
        }
        public IActionResult GetSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");

            return Content($"name : {name}, age : {age}");
        }
    }
}
