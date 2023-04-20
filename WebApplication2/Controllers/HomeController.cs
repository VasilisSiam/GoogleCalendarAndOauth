using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using Google.Apis.Calendar.v3;
using System.Web;

namespace WebApplication2
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        [Route("Home/Index")]
        public ActionResult OauthRedirect() {
            var credentialsFile = "C:\\Users\\Vasilis\\source\\repos\\WebApplication2\\WebApplication2\\Files\\Credentials.json";

            JObject credentials= JObject.Parse(System.IO.File.ReadAllText(credentialsFile));
            var client_id = credentials["client_id"];

            var redirectUrl = "https://accounts.google.com/o/oauth2/v2/auth?" +
                "scope=https://www.googleapis.com/auth/calendar+https://www.googleapis.com/auth/calendar.events&" +
                "access_type=offline&" +
                "include_granted_scopes=true&" +
                "response_type=code&" +
                "state=Hello_There& " + //maybe hello there to state
                "redirect_uri=https://localhost:7185/oauth/callback& " +   //Το redirect θα μπει της σελιδας τα login 
                "client_id=" + client_id;

            return Redirect(redirectUrl);


        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
