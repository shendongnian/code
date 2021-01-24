    namespace MyNamespace
    {
        public static class DataHelpers
        {
            public static string SysnamePath ( string db , string schema , string table )
            {
                return "[ " + db + " ].[ " + schema + " ].[ " + table + " ]";
            }
        }
    }
