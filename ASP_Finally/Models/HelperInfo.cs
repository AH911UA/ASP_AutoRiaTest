using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_Finally.Models
{
    public class HelperInfo
    {
        public static string KEY = "QNIVsN6gc5qBCPfokonn3Lho98AFTyMYADEDcoCw";
       
        public static string URLGetCar = "https://developers.ria.com/auto/info?api_key=QNIVsN6gc5qBCPfokonn3Lho98AFTyMYADEDcoCw&auto_id=";
        public static string URLGetID = "https://developers.ria.com/auto/search?api_key=QNIVsN6gc5qBCPfokonn3Lho98AFTyMYADEDcoCw";

        public static string URL_F_INFO(string id)
            => $"https://developers.ria.com/auto/fotos/" + id + "?api_key=" + KEY;

        public static string URL_BACK_INFO(string id)
            => $"https://developers.ria.com/auto/info?api_key=" + KEY + "&auto_id=" + id;


        //TempData["test"] = $"<img src='{pic.ToString()}' width='200'; height='200'></ing>";


        //StringBuilder sb = new StringBuilder(); // delete
        //        if (!System.IO.File.Exists("D:/test2.txt"))
        //            using (System.IO.File.Create("D:/test2.txt")) { }

        //        System.IO.File.WriteAllText("D:/test2.txt", sb.ToString());
    }
}