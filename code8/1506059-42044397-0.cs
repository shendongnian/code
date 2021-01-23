    private const string FirstOptionText = "First option";
    private const string SecondOptionText = "Second option";
    private async void BotClientOnMessage(object sender, MessageEventArgs e)
    {
        switch (e.Message.Text)
        {
            case FirstOptionText:
                await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "You chose the first option", replyMarkup:new ReplyKeyboardHide());
                break;
            case SecondOptionText:
                await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "You chose the second option", replyMarkup:new ReplyKeyboardHide());
                break;
            default:
                await BotClient.SendTextMessageAsync(e.Message.Chat.Id, "Hi, select an option!",
                    replyMarkup: new ReplyKeyboardMarkup(new[]
                    {
                        new KeyboardButton(FirstOptionText),
                        new KeyboardButton(SecondOptionText),
                    }));
                break;
        }
    }
