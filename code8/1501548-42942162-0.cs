    static void Main(string [] args)
    {
        using (var instance = new SingleInstance(ExecutionEnvironment.Current.AppId))
        {
            if (instance.IsFirstInstance)
            {
                ExecutionEnvironment.Current.StartupArgs = args;
                HockeyClient.Current.Configure("xxxxxxxxxxxxxxxxxxx");
                try
                {
                    HockeyClient.Current.SendCrashesAsync();
                }
                catch { }
                using (var program = new Program())
                {
                    program.Show();
                }
            }
        }
    }
