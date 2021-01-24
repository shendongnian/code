            var tuple = Tuple.Create("MyKey", "MyValue");
            var list = new List<string>();
            var str = tuple.ToString();
            list.Add(str);
            // str has the value "(MyKey, MyValue)"
            Console.WriteLine(str);
            
            int comma = str.IndexOf(", ");
            string key = str.Substring(1,comma-1);
            string valuee = str.Substring(comma+2,str.Length-key.Length-4);
            var tuple2 = Tuple.Create(key, valuee);
            // 'tuple2' is now equal to the orignal 'tuple'
