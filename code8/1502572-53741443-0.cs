        private static void Main(string[] args)
        {
            try
            {
                string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (exeDir != null)
                {
                    Directory.SetCurrentDirectory(exeDir);
                }
