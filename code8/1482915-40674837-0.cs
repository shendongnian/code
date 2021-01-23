        static void Main(string[] args)
        {
            int initialLoopValue = Properties.Settings.Default.ValueToResume;
            for (int i = initialLoopValue; i <= 2000; i += 64)
            {
                //do work
                checkCountProgress(i, 2000);
            }
            Properties.Settings.Default.Reset(); //Loop was completed, we can reset the setting to 0
        }
        public static void checkCountProgress(int countProgress, int totalDataSize)
        {
            if (countProgress > 600)
            {
                Properties.Settings.Default.ValueToResume = countProgress;
                Properties.Settings.Default.Save();
                Environment.Exit(0); //force application exit
            }
        }
    }
