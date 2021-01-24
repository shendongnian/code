    using Menu;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Telegram.Bot;
    using Telegram.Bot.Args;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;
    using Telegram.Bot.Types.InlineKeyboardButtons;
    using Telegram.Bot.Types.ReplyMarkups;
    
    
    namespace TelegramMVC
    {
        public class MvcApplication : System.Web.HttpApplication
        {
    
            Telegram.Bot.TelegramBotClient Bot = new TelegramBotClient("my_api_key");
    
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
    
                Bot.OnMessage += Bot_OnMessage;
                Bot.StartReceiving();
            }
    
            private void Bot_OnMessage(object sender, MessageEventArgs messageEventArgs)
            {
                var message = messageEventArgs.Message;
    
                if (message == null || message.Type != MessageType.TextMessage) return;
    
                if (message.Text.Contains("/start")) 
                {
                    string Str = "Start Recived";
                    Bot.SendTextMessageAsync(message.Chat.Id, Str, replyMarkup: MainMenu.ShowMenu(message));
    
                }
                else if (message.Text.Contains("/Stop"))
                {
                    string Str = "Stop Recived";
                    Bot.SendTextMessageAsync(message.Chat.Id, Str, replyMarkup: FollowerMenu.ShowFollowerMenu(message));
                }
              
            }
            
        }
    }
 
