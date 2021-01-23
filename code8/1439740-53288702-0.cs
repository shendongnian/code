    namespace MatrixGuide
    {
        public static class GV
        {
            // In this class all gobals are defined
    
            static string _cURL;
            public static string cURL // URL (IP + Port) on that the application has to listen
            {
                get { return _cURL; }
                set { _cURL = value; }
            }
    
            static bool _bdummy1;
            public static bool bdummy1 // 
            {
                get { return _bdummy1; }
                set { _bdummy1 = value; }
            }
    
            static int _idummy1;
            public static int idummy1 // 
            {
                get { return _idummy1; }
                set { _idummy1 = value; }
            }
    
            static bool _bFehler_Ini;
            public static bool bFehler_Ini // 
            {
                get { return _bFehler_Ini; }
                set { _bFehler_Ini = value; }
            }
    
            // add further  GV variables here..
        }
        // Add further classes here... 
    }
