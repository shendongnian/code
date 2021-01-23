        private static void Main(string[] args)
        {
            try
            {
                string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (exeDir != null)
                {
                    Directory.SetCurrentDirectory(exeDir);
                }
                if (!Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: browserProcessHandler))
                {
                    throw new Exception("Unable to Initialize Cef");
                }
