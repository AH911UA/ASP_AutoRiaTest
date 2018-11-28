using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Finally.Models
{
    public class Announcement
    {
        public string ID { get; set; }

        public string NameCar { get; set; }
        public string LocationCityName { get; set; }
        public string Phone { get; set; }
        public string USD { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string MarkName { get; set; }

        public List<string> PhotoData { get; set; }

        public Announcement() { PhotoData = new List<string>(); }
        public Announcement(string id) : this() { ID = id; }
    }
}