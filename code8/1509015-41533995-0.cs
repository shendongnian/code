     var newMsg = new SendMessage(update.Message.Chat.Id, "msg")
                                {
                                    ReplyMarkup = new InlineKeyboardMarkup()
                                        {
                                            InlineKeyboard = new[] 
            {
                new[] { new InlineKeyboardButton{Text="A",Url = "http://www.A.com/"}, new InlineKeyboardButton(){Text="B",Url = "http://www.B.com/"} }
                
            }
                                        }
                                };
    
                                await bot.MakeRequestAsync(newMsg);
                                continue;
