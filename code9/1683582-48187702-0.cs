    // first join the two collections on same year.
    // we only need properties Country, Admin, Finance:
    var result = myDbContext.MultipleRowValueTable.Join(myDbContext.UsedAmountTable,
        multipleRow => multipleRow.Year,    // from every multipleRow take the year
        usedAmount => usedAmount.Year,      // from every usedAmount take the year
        (multipleRow, usedAmount) => new    // when they match make a new object
        {
            Country = multipleRow.Country,
            Admin = multipleRow.Admin,
            UsedAdmin = usedAmount.Admin,
            Finance = multipleRow.Finance,
            UsedFinance = usedAmount.Finance,
        })
        // group the elements from this join table into groups with same Country
        .GroupBy(joinedItem => joinedItem.Country,  // all items in the group have this Country
             joinedItem => new                      // the elements of the group
             {
                 Admin = joinedItem.Admin,
                 UsedAdmin = joinedItem.UsedAdmin,
                 Finance = joinedItem.Finance,
                 UsedFinance = joinedItem.UsedFinance,
             })
             // finally: from every group take the Key (which is the Country) 
             // and the sum of the Admins and Finances in the group
             .Select(group => new
             {
                  Country = group.Key,
                  SumAdminColumn = group
                      .Select(groupElement => groupElement.Admin)
                       .Sum(),
                  ... // others are similar
             });
        
        // from every group take the elements and sum the properties
        .Select(group => new
        {
            Id = multipleRowValue.Id,
            Year = multipleRowValue.Year,
            Country = multipleRowValue.Country,
        }
