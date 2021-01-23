       Dictionary<int,string> dicta = new Dictionary<int, string>();
            Dictionary<int, string> dictb = new Dictionary<int, string>();
            dicta.Add(1, "Hi");
            dicta.Add(2, "Hello");
            dictb.Add(2, "Hiyo");
            dictb.Add(1, "Hllow");
            var list = (from d1 in dicta
                       let temp = dictb.FirstOrDefault(d2 => d2.Value.Contains(d1.Value))
                       where temp.Value != null
                       select new { d1.Key, temp.Value }).ToDictionary(d => d.Key ,d => d.Value );
