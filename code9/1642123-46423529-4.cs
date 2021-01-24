            var lst = new List<Customer>(); //List of objects declared
            lst.AddRange(
                new List<Customer>() {
                    new Customer()
                    {
                        CustomerId = 1001,
                        CustomerName = "John",
                        Address = "On Earth",
                        Status = "Active"
                    },
                    new Customer()
                    {
                        CustomerId = 1002,
                        CustomerName = "James",
                        Address = "On Earth",
                        Status = "Inactive"
                    }
                }
            );
            var status = Console.ReadLine();
            var selected = lst.Where(x => x.Status.ToUpper() == status.ToUpper()).ToList();
            foreach (var item in selected)
            {
                Console.WriteLine(item.CustomerId + " " + item.CustomerName);
            }
