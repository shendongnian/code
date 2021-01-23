    static void Main(string[] args)
    {
        try
        {
            // Application code goes here
        }
        catch (Exception)
        {
            var applicationPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Process.Start(applicationPath);
            Environment.Exit(Environment.ExitCode);
        }
    }
