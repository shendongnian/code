        object locker = new object();
        using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
        {
            int id;
            using (var context = new MyContext())
            {
                var order = new Order { Name = "Test", Flags = 1 };
                context.Orders.Add(order);
                context.SaveChanges();
                id = order.Id;
            }
            var transactionToUse = Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete);
            Enumerable.Range(1, 10).AsParallel().ForAll(x =>
            {
                lock (locker)
                {
                    using (var ts = new TransactionScope(transactionToUse))
                    {
                        using (var context = new MyContext())
                        {
                            var orderItem = context.Orders.FirstOrDefault(order => order.Id == id);
                            if (orderItem == null)
                            {
                                Console.WriteLine($"Thread: {x} could not find order.");
                            }
                            else
                            {
                                Console.WriteLine($"Thread: {x} found order.");
                                //TODO: further processing.
                            }
                        }
                        ts.Complete();
                    }
                }    
            });
                
            scope.Complete();
        }
