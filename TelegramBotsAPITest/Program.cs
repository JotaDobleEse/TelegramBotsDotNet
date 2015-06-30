using System;
using System.Collections.Generic;
using System.IO;
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
            var api = new BotApi("99977343:AAEYpKeKikzmLcGtpbydqTNJvW7RSLo66go");

            //var user = api.GetMe();

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup();
            keyboard.Keyboard = new string[1][];
            keyboard.Keyboard[0] = new string[] { "prueba" };

            //var message = api.SendMessage(21268357, "Prueba chat");
            //var message1 = api.SendMessage(21268357, "Prueba teclado chat", keyboard);
            //var message2 = api.SendMessage(-19537380, "Ocultar teclado", new ReplyKeyboardHide() { HideKeyboard = true });
            //var message3 = api.SendMultimedia(21268357, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "dns.png"), MultimediaType.Photo, "tchusami");
            //var message4 = api.ResendPhoto(21268357, "AgADBAADrKcxG3-I9QV5V8vcAZ3hKjlkYzAABMSoh-HNA2UdqE8AAgI");
            //var message5 = api.SendAudio(21268357, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), @"Ciniko el octavo arte - La teoría del todo\01. Ciniko el octavo arte - La teoria del todo [Producido por BeatCN producciones] - www.hhgroups.com.mp3"));
            //api.ResendAudio(-19537380, "AwADBAADAgADf4j1BTXM7czz0tsJAg");
            //api.SendChatAction(-19537380, ChatActions.Typing);
            //var result = api.GetUserProfilePhotos(32996065);
            //var updates = api.GetUpdates();
            //api.SetWebhook();
            
            //Console.WriteLine(user.FirstName);

            Console.ReadLine();
        }
    }
}
