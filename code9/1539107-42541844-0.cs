    static void Main(string[] args)
    {
        TalkingBot bot = new TalkingBot();
        try
        {
            Console.WriteLine("Thinking started...");
            Console.WriteLine(bot.Think("Some input...", 2000));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }
        Console.ReadLine();
    }
