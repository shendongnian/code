    var customers = _dbContext.Customer
                        .Join(_dbContext.Address
                        , c => c.Id
                        , a => a.EntityId, (c, a) => new {  c.Id, Address = a }).GroupBy(j => j.Id);
    
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"Customer :{customer.Key} , Address : { customer.Count() }");
                        foreach (var Addr in customer)
                        {
                            Console.WriteLine(Addr.xxxx);
                        }
                    }
