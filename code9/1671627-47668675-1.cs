        private static DateTime lastRunAt;
        private static object loadingTokenLock = new object();
        private static bool TokenUpdateNeeded
        {
            get
            {
                return DateTime.UtcNow.DayOfYear != lastRunAt.DayOfYear;
            }
        }
        public static void TryLoadToken()
        {
            if (TokenUpdateNeeded)
                lock (loadingTokenLock)
                    if (TokenUpdateNeeded)
                        LoadFromFile();
        }
        public static void LoadFromFile()
        {
            // loads Token value from a settings file
            lastRunAt = DateTime.UtcNow;
        }
        void Session_Start(object sender, EventArgs e)
        {
            TryLoadToken();
        }
