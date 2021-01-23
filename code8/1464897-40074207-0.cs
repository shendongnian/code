         private static DateTime lastUpdate
         public static DateTime LastUpdate
            {
                get { return lastUpdate; }
                set { lastUpdate = DateTime.Now; }//or: = value
            }
