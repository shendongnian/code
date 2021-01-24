            private static async void BotOnUpdateReceived(object sender, UpdateEventArgs e)               
                  {               
                    var message = e.Update.Message;
                    if (message == null || message.Type != MessageType.Text) return;
                    var text = message.Text;
                    ConsoleWriteLine(text);
                    await Bot.SendTextMessageAsync(message.Chat.Id, "_Recieved Update._", ParseMode.Markdown);
                   }
