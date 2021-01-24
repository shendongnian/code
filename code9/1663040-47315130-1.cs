        static void Main(string[] args)
        {
            var samples = new List<Sample>
            {
                new Sample("p1", "aaa,bbb,ccc,ddd"),
                new Sample("p1", "bbb,ccc,xxx"),
                new Sample("p2", "aaa,bbb,ccc"),
                new Sample("p1", "xxx")
            };
            var grp = samples.GroupBy(b => b.property)
                .Where(a => a.Key == "p1")
                .SelectMany(s => s.ToList())
                .Where(b => b.someListProperty.Contains("ccc"));
            foreach (var g in grp)
                System.Console.WriteLine(g.ToString());
            System.Console.ReadLine();
        }
        private class Sample
        {
            public string property;
            public List<string> someListProperty;
            public string someOtherPropery;
            public Sample(string p, string props)
            {
                property = p;
                someListProperty = props.Split(',').ToList();
                someOtherPropery = string.Concat(from s in someListProperty select s[0]);
            }
            public override string ToString()
            {
                return $"{property} - {string.Join(", ", someListProperty)} -"
                           + $" ({someOtherPropery})";
            }
        }
