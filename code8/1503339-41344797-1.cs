    public void Test()
        {
            var list = new List<User>();
            list.Add(new User {UserId = 1, Property1 = 1, Property2 = 1, Property3 = 10, Testval = 35});
            list.Add(new User {UserId = 1, Property1 = 2, Property2 = 2, Property3 = 3, Testval = 45});
            list.Add(new User {UserId = 1, Property1 = 5, Property2 = 5, Property3 = 6, Testval = 55});
    
    
            var zz = list.Where(w => w.Property1 != 1)
                .GroupBy(t => new {ID = t.UserId})
                .Select(w => new
                {
                    average = w.Average(a => a.Testval),
                    count = w.Count(),
                    rest = list.Where(r => r.Property1 == 1).Average(a => a.Testval)
                }).Single();
        }
