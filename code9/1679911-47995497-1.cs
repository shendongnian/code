    public List<Fruit> GetFruit(int userId, int page, int itemsPerPage)
    {
        var query = repo.Get<Fruit>(e => e.userId == userId);
        var dbResults = query.Skip((itemsPerPage * page) - itemsPerPage).Take(itemsPerPage).ToList();
        return new PagedList<Fruit>()
        {
             Results = dbResults,
             PageNumber = page,
             TotalCount = query.Count(),
        }
    }
