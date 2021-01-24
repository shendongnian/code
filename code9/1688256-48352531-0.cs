       var customers = await db.Customers.Where(c =>
        c.Categories.Any(cate =>
         model.CustomerCategories.Contains(cate.CategoryId)
        )
       ).ToListAsync();
    
       var opportunities = new List<Opportunity>(customers.Count);
    
       foreach(var customer in customers) {
        if (String.IsNullOrEmpty(model.Name)) {
         opportunityName = customer.FullName;
        }
        var opportunity = new Opportunity {
         StepId = model.StepId,
          Name = opportunityName,
          Email = customer.Email,
          Phone = customer.Phone,
          CustomerId = customer.Id,
          Status = IdentityStatus.Active,
          ExpectedRevenue = model.ExpectedRevenue,
          Probability = model.Probability,
          Notes = model.Note,
          Deadline = model.Deadline,
          OwnerId = OwnerId,
          Reason = model.Reason,
          Revenue = model.Revenue,
          CompleteDate = model.CompleteDate,
        };
        opportunities.Add(opportunity);
        //db.Opportunities.Add(opportunity);
    
       }
    
       db.Opportunities.AddRange(opportunities);
       await db.SaveChangesAsync();
    
       //foreach (var opportunity in opportunities)
         // Console.WriteLine(opportunity.YourIdPropertyHere);
