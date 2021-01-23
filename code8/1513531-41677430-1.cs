    static void Main(string[] args)
    {
        Service bot = new Service();
        bot.Connect().Wait();
        bot.Authenticate(etc.Constants.PhoneNumber).Wait();
        Debugger.Break();
    }
