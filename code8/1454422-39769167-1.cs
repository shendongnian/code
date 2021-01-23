     void Caller()
        {
                    foreach (var entity in EntityCollection)
                    {
                        if (entity.Name == "Account")
                        {
                            id = MethodToRefactor<Account>(db, new [] {a => a.Name}, ...);
                        }
                        else if (entity.Name == "Customer")
                        {
                            id = MethodToRefactor<Customer>(db, new [] {c => c.FirstName, c => c.LastName}, ...);
                        }
            }
    }
