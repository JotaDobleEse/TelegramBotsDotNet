using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotsAPI;

namespace TelegramBotsAPITest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var api = BotApi.GetInstance("");

            var user = api.GetMe();

            Console.WriteLine(user.first_name);

            Console.ReadLine();
        }
    }
}
