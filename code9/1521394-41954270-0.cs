    var searchedCustomers = Customers
        .Select(c => new { 
            Customer = c,
            FilteredProjects = c.Projects
                .Where(p => string.Equals(p.Name, nameFilter, StringComparison.InvariantCultureIgnoreCase))
                .ToList()
        })
        .Where(x => x.FilteredProjects.Any())
        .Select(x => new Customer{ 
            Name = x.Customer.Name,  
            Projects = x.FilteredProjects 
        }); 
