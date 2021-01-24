    using (var dbContext = new MyDbContext())
    {
        var result = dbContext.Customers
            .Where(customer => customer.Nbr == 1234)
            .Select(customer => new
            {
                // select the customer properties you will use, for instance
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                // you only want the newest assignment:
                NewestAssignment = customer.Assignments
                   .OrderByDescending(assignment => assignment.AssignmentTime)
                   .Select(assignment => new
                   {   // take only the Assignment properties you will use:
                       Location = assignment.Location,
                       AssignmentTime = assignment.AssignmentTime,
                   }
                   .FirstOrDefault(),
            });
        }
    }
