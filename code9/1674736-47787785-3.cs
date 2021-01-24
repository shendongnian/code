            List<Customer> list = new List<Customer>();
            list.Add(new Customer() { FName = "A", LName = "L" });
            list.Add(new Customer() { FName = "A", LName = "L" });
            list.Add(new Customer() { FName = "B", LName = "L" });
            list.Add(new Customer() { FName = "B", LName = "L" });
            list.Add(new Customer() { FName = "C", LName = "L" });
            var list2 = list.GroupBy(x => new { x.FName, x.LName}).Select(x => new Customer
            {
                Count = x.Count(),
                FName = x.First().FName,
                LName = x.First().LName
            })
            .Where(x => x.Count > 1).ToList();
            foreach (var item in list2)
            {
                Console.WriteLine($"FName: {item.FName}, LName: {item.LName}, Count: {item.Count}");
            }
