    return (from b in _dbcontext.Books
            join g in _dbcontext.GenreTypes on b.GenreTypeId equals g.Id
            group g by g.Name into n
            select new BooksChart {
                category_name = n.Key,
                value = n.Count()
            }).ToList();
