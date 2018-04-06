using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Random_Passcode.Controllers
{
    public class PasscodeController : Controller
    {

	    [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("get_passcode/{count}")]
        public JsonResult GetPasscode(int count)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int length = 14;
            string newPasscode = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            var data = new {
                count = count + 1,
                passcode = newPasscode
            };

            return Json(data);
        }
    }
}