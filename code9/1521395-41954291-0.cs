    Customers
      .Where(c => c.Projects.Any(p => p.Name.ToLowerInvariant().Contains(lowerCaseFilter)))
      .Select(c => new Customer
      {
        // set all other properties
        Projects = c.Projects
          .Where(p => p.Name.ToLowerInvariant().Contains(lowerCaseFiler))
          .ToList()
      });
