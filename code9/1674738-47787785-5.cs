            List<Customer> list = new List<Customer>();
            list.Add(new Customer() { FName = "A", LName = "L" });
            list.Add(new Customer() { FName = "A", LName = "L" });
            list.Add(new Customer() { FName = "B", LName = "L" });
            list.Add(new Customer() { FName = "B", LName = "L" });
            list.Add(new Customer() { FName = "C", LName = "L" });
            var isDup = list.Where(x => x.FName.Equals("A") && x.LName.Equals("L")).Count() > 1;
            var isNotDup = list.Where(x => x.FName.Equals("C") && x.LName.Equals("L")).Count() > 1;
