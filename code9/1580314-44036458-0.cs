    public static void Try(Action action, [CallerMemberName] string cmn = "")
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
			Console.WriteLine(ex.ToString());
        }
    }
