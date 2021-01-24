    static int Main(string[] args)
        {
            try
            {
                var options = new Options();
                if (!Parser.Default.ParseArguments(args, options))
                {
                    options.GetUsage();//Prints to console
                    (...)
