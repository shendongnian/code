    _telegramClient = new TelegramBotClient(ConfigurationManager.AppSettings["TelegramApiKey"]);
    _telegramClient.OnMessage += BotOnMessageReceived;
    _telegramClient.StartReceiving();
    var test = await _telegramClient.GetFileAsync(message.Photo[message.Photo.Count() - 1].FileId);
    var image = Bitmap.FromStream(test.FileStream);
    image.Save(@"C:\\Users\xxx\Desktop\test.png");
    // message.Photo.Count()-1 => the biggest resolution
