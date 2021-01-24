    var result = SubCategories 
        // group them into groups with same CategoryId
        .GroupBy(subCategory => subCategory.CategoryId
        // from every group take the properties you want: 
        .Select(group => new
        {
            // All SubCategories in one group belong to the same Category.
            // For efficiency, take only the Category properties you plan to use,
            CommonCategory = group.Key.Select(category => new
            {
                // take the category properties you want to use
            }
            // The group has a lot of SubCategories.
            // For each subcategory select only the properties you want to use
            SubCategories = group.Select(subCategory => new
            {
                // one of the properties you want is the number of Tickets of this SubCategory:
                TicketCount = subCategory.Tickets.Count(),
                // for efficiency: select only SubCategory properties you plan to use:
                Property1 = subCategory.Property1,
                Property2 = subCategory.Property2,
                ...
            }),
        });
