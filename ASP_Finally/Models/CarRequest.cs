using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ASP_Finally.Models
{
    public class CarRequest
    {
        public static async Task<Announcement> GetAllInfo(string id)
        {
            string json = await RequestJson(HelperInfo.URL_BACK_INFO(id));

            System.IO.File.WriteAllText("D:/t.txt", json);
            var o = JObject.Parse(json);

            Announcement an = new Announcement();
            foreach (var item in o)
            {
                switch (item.Key)
                {
                    case "locationCityName": an.LocationCityName = item.Value.ToString(); break;
                    case "USD": an.USD = item.Value.ToString(); break;
                    case "modelName": an.NameCar = item.Value.ToString(); break;
                    case "userPhoneData": an.Phone = item.Value["phone"].ToString(); break;
                    case "autoData": an.Description = item.Value["description"].ToString(); break;
                }
            }

            return an ;
        }

        private static async Task<string> RequestJson(string url)
        {
            string responseBody = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return responseBody;
        }

        public static async Task<string> GetPostID() => await RequestJson(HelperInfo.URLGetID);


        public static async Task<string> GetPostFirstInfo(string id, List<Announcement> announcements)
        {
            foreach (var item in announcements)
            {
                string responseBody = await RequestJson(HelperInfo.URL_F_INFO(id));

                foreach (var elem in JObject.Parse(responseBody))
                {
                    if (elem.Key == "data")
                    {
                        string idPhoto = GetIDPhoto(elem.Value[id].ToString());
                        announcements.Last().Year = elem.Value[id][idPhoto]["date_add"].ToString();
                        return elem.Value[id][idPhoto]["formats"][0].ToString();
                    }
                }
                break;
            }
            return "Empty";
        }


        public static string GetIDPhoto(string url)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 6; i < url.Length; i++)
            {
                if (char.IsDigit(url[i]))
                    sb.Append(url[i]);
                else break;
            }

            return sb.ToString();
        }
    }
}