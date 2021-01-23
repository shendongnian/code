    static void Main(string[] args)
    {
        Service bot = new Service();
        Authenticate(bot).Wait();
        Debugger.Break();
    }
    static async Task Authenticate(Service bot)
    {
        await bot.Connect();
        await bot.Authenticate(etc.Constants.PhoneNumber);
    }
