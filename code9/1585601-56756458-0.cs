    public class DataManager
    {
        private static DataManager __instance = null;
        private static readonly object _padlock = new object();
    
        public static DataManager Instance
        {
            get
            {
                if (__instance == null)
                {
                    lock (_padlock)
                    {
                        if (__instance == null)
                        {
                            __instance = new DataManager();
                        }
                    }
                }
                return __instance;
            }
        }
        private DataManager()
        { }
        // your stuff as needed ...
    }
