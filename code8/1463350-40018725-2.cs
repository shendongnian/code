        public List<Foo> GetData()
        {
            List<Foo> rows = new List<Foo>();
            var x = new Dictionary<string, object>();
            x.Add("sss","sss");
            x.Add("zzz", "zzz");
            x.Add("aaa", "aaa");
            var z = new Foo();
           z.Inputs = x;
            
            rows.Add(z);
            rows.Add(z);
            return rows;
        }
