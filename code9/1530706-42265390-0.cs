     private static void Splitter()
        {
            string data = "[City, Delhi]&[State, DL]&[Country, IN]";
            Dictionary<string,string> dOutput = new Dictionary<string,string>();
            string[] sArr = data.Split('&');
            var v = from p in sArr
                    select p.Replace("[", "").Replace("]", "").Split(',');
             var v2 = (from p in v
                     select p).ToDictionary(item => item[0], item => item[1]);
            
            Console.WriteLine(v2.Count());
        }
