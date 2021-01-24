            var customerTest = new Customer
            {
                Id = Guid.NewGuid(),
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = Guid.NewGuid(),
                        Customer = new Customer{ Id = Guid.NewGuid() }
                    }
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        Id = Guid.NewGuid(),
                        Customer = new Customer{ Id = Guid.NewGuid() },
                        Address = new Address{ Id = Guid.NewGuid() }
                    }
                }
            };
