        class Class1
        {
            public string Produce { get; set; }
            public string CompanyName { get; set; }
            public string Link { get; set; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<Class1> lst = new List<Class1>();
            lst.Add(new Class1() { Produce = "a", CompanyName="b", Link="c" });
            lst.Add(new Class1() { Produce = "a", CompanyName = "b", Link = "c" });
            lst.Add(new Class1() { Produce = "a", CompanyName = "d", Link = "c" });
            lst.Add(new Class1() { Produce = "e", CompanyName = "b", Link = "c" });
            var result = lst.GroupBy(x => x.Produce + x.CompanyName + x.Link).Select(g => new { Produce = g.First().Produce,
                Company = g.First().CompanyName,
                Link = g.First().Link,
                Count = g.Count()
            }).ToList();
        }
