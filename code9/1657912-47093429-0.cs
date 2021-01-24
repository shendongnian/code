    using (var dbContext = new MyDbContext())
    {
        var result = dbContext.Customers
        .Where(customer => customer.Nbr == 1234)
        .Select(customer => new Customer
        {
            // select the customer properties you will use, for instance
            Id = customer.Id,
            Nbr = customer.Nbr,
            Name = customer.Name,
            //…and lot of other property mapping
            // you only want the newest assignment:
            Assignments = new Collection<Assignments>
                {
                     customer.Assignments.OrderByDescending(assignment => assignment.AssignmentTime)
                     .FirstOrDefault()
                }
            });
        }
    }
