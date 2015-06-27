using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;

namespace TelegramBotsAPI
{
    public class BotApi
    {
        public string Token { get; private set; }
        public string BaseUrl { get { return "https://api.telegram.org/bot" + Token + "/"; } }
        private BotApi(string token)
        {
            Token = token;
        }

        public static BotApi GetInstance(string token)
        {
            return new BotApi(token);
        }

        public User GetMe()
        {
            var request = (HttpWebRequest)WebRequest.Create(BaseUrl + "getMe");

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Console.WriteLine(responseString);

            
            var user = JsonConvert.DeserializeObject<User>(responseString);
            return user;
        }
    }
}
