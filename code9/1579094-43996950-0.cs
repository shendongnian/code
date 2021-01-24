    var list = new List<string>();
            list.Add("a");
            list.Add("ab");
            list.Add("ab");
            list.Add("abc");
            list.Add("lmn");
            list.Add("xyz");
            
            var q = list.AsEnumerable().Select(s => s).Distinct().OrderByDescending(s => s).ToList();
            
            foreach(var i in q)
            {
                Console.WriteLine(i);
            }
