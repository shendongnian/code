        List<MyClass> A = new List<MyClass>();
            A.Add(new MyClass() { Close = 0.2m, Symbol = "Test1", Date = DateTime.Now });
            A.Add(new MyClass() { Close = 0.3m, Symbol = "Test1", Date = DateTime.Now });
            A.Add(new MyClass() { Close = 0.1m, Symbol = "Test2", Date = DateTime.Now });
            A.Add(new MyClass() { Close = 0.2m, Symbol = "Test2", Date = DateTime.Now });
            SortedList<string, List<MyClass>> B = new SortedList<string, List<MyClass>>();
            A.OrderByDescending(o => o.Date).GroupBy(o => o.Symbol).ToList()
                .ForEach(o => B.Add(o.Key, o.ToList()));
            Console.WriteLine(B.Count);
            Console.ReadKey();
