    internal IQueryable<ROWTYPE> SelectTable(string category)
    {
        switch (category)
        {
            case "News": return db.News;
            case "Sport": return db.Sport;
            case "Arts": return db.Arts;
            default: throw new ArgumentException("Unsupported category: " + category);
        }
    } 
    var table = SelectTable(Category);
    var userPost = table
                    .Include(x => x.Popular)
                    .Include(x => x.Popular.Category)
                    .Where(x => x.User.Id == userId)
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<PostViewModel>(_mapper.ConfigurationProvider)
                    .ToPagedList(pageIndex, pageSize);
