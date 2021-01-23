    var subcategories = user.SubCategories.ToList();
    foreach (var temp in _contentRepository.FindManyBy(
         c =>
           c.Country.Id == country.Id && c.Category.Id == theCategory.Id &&
          subcategories.Contains( subCategory.Id ) ).ToList()))
     {
        posts.AddRange(temp);
     }
