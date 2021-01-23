    var totalClassified = db.UserClassifiedsCategories
                            .Where(c => c.UserId == userId)
                  .ProjectTo<UserClassifiedsCategoriesViewModel>(mapper.ConfigurationProvider)
                  .ToList();
    var orderList = new List<String>
    {
        "Green",
        "Blue",
        "Yellow",
        "Gray"
    };
    var totalClassifiedOrdered = totalClassified.OrderBy(d => orderList.IndexOf(d.Name));
