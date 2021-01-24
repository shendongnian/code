    private static async Task<User> DoSomethingAsync3()
    {
        try
        {
            var user = await Task.Run(() => LongRunner.LongRunnerInstance.DoSomethingThatTakesReallyLong());
            Console.WriteLine(user.Id);
            return user;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
