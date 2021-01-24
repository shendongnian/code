    var activeProducts = _context.Products.Where(p => !p.IsDeleted);
    if (!string.IsNullOrEmpty(searchTerm))
    {
      if (searchType == "category")
      {
          // See the change here?
          activeProducts = activeProducts
              .Where(p => string.Equals(
                  p.Category.Name, 
                  searchTerm.Trim(),
                  StringComparison.CurrentCultureIgnoreCase))
              .OrderBy(p => p.Category.Name)
              .Skip(_recordsPerPage * (page - 1))
              .Take(_recordsPerPage);
      }
      else
      {
          // Here.
          activeProducts = activeProducts
            .Where(p => string.Equals(
                p.Brand.Name, 
                searchTerm.Trim(),
                StringComparison.CurrentCultureIgnoreCase))
            .Skip(_recordsPerPage * (page - 1))
            .Take(_recordsPerPage);
      }
    }
    else
    {
        // And here.
        activeProducts = activeProducts
            .Skip(_recordsPerPage * (page - 1))
            .Take(_recordsPerPage);
    }
