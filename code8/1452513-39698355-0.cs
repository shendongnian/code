    public static string IEHackforTime(string time)
        {
            string newTime = "";
            var arr = time.ToCharArray();
            foreach( var c in arr)
            {
                if (Char.IsNumber(c) || c==':' )
                {
                    newTime += c.ToString(); // No need of StringBuilder, array is small enough
                }
            }
            return newTime;
        }
