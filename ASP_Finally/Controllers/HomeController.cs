using ASP_Finally.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace ASP_Finally.Controllers
{
    public class HomeController : Controller
    {
        List<Announcement> announcements = new List<Announcement>();

        public async Task<ActionResult> Index()
        {
            string json = await ASP_Finally.Models.CarRequest.GetPostID();
            var o = JObject.Parse(json);

            foreach (var item in o)
                if (item.Key == "result")
                {
                    foreach (var id in item.Value["search_result"]["ids"])
                    {
                        announcements.Add(new Announcement(id.ToString()));
                        announcements.Last().PhotoData.Add(await CarRequest.GetPostFirstInfo(announcements.Last().ID.ToString(), announcements));
                        announcements.Last().LocationCityName = id.ToString();

                        Announcement tmpAnn = await CarRequest.GetAllInfo(id.ToString());
                        announcements.Last().LocationCityName = tmpAnn.LocationCityName;
                        announcements.Last().NameCar = tmpAnn.NameCar;
                        announcements.Last().Phone = tmpAnn.Phone;
                        announcements.Last().USD = tmpAnn.USD;
                        announcements.Last().Description = tmpAnn.Description;
                    }
                    break;
                }

            return View(announcements);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}