        class MyClass
        {
            public DateTime Time { get; set; }
            public int OtherVal { get; set; }
            public double AggField { get; set; }
        }
        
            List<MyClass> lst = new List<MyClass>();
            lst.Add(new MyClass { Time = DateTime.Today, OtherVal = 4, AggField = 1});
            lst.Add(new MyClass { Time = DateTime.Today, OtherVal = 4, AggField = 2 });
            lst.Add(new MyClass { Time = DateTime.Today, OtherVal = 3, AggField = 3 });
            var grouped = lst.GroupBy(c => new Tuple<DateTime, int>(c.Time, c.OtherVal));
            var dic = new Dictionary<Tuple<DateTime, int>, double>();
            foreach (var group in grouped)
            {
                var agg = group.Average(c => c.AggField);
                dic.Add(group.Key, agg);
            }
