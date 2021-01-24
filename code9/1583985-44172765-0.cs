    Category[] categories = {
        new Category { Title ="Abc", SubCategory = new List<NameValue> 
            {  new NameValue {  Name = "B", Value = "5"},
               new NameValue {  Name = "A", Value = "5"} } },
        new Category { Title ="Xyz", SubCategory = new List<NameValue> 
            { new NameValue { Name = "A", Value = "10" } } }};
    // First order by categories   
    var cats = categories.OrderBy(c => c.Title)
        // Then create a new category and order by sub categories 
        .Select(x => new Category { Title = x.Title, 
                         SubCategory = x.SubCategory.OrderBy(y => y.Name) });
