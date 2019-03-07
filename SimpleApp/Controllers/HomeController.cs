using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string colorSessionKey="color";

        // GET: Home
        public ActionResult Index()
        {
            return View(HttpContext.Application["events"]);
        }

        [HttpPost]
        public ActionResult Index(Color color)
        {
            return VotingResults(color);
        }

        [HttpGet]
        public ActionResult Modules()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Modules(Color color)
        {
            return VotingResults(color);
        }

        public ActionResult Events()
        {
            return View(GetTimestamps());
        }

        private List<string> GetTimestamps()
        {
            return new List<string>
            {
                string.Format("App timestamp: {0}", HttpContext.Application["app_timestamp"]),
                string.Format("Request timestamp: {0}", Session["request_timestamp"])
            };
        }

        private ActionResult VotingResults(Color color)
        {
            Color? oldColor = Session[colorSessionKey] as Color?;
            //The user has already voted
            if (oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            }
            else
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session[colorSessionKey] = color;
            return View(HttpContext.Application["events"]);
        }
    }
}