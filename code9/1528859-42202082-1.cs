    public IEnumerable<ResultViewModel> GetData()
    {
        return dbItemsAsQueryable.Select(item => new ResultViewModel
        {
            Id = item.Id,
            Name = item.Name,
            // other properties
        }).ToList();
  
    }
