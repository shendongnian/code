    int start = 0;
    int batch = 1000;
    while (start < idList.Count())
    {
      var batchSet = idList.Skip(start).Take(batch);
      nameList.AddRange(
                 db.Books.Where(x => batchSet.Contains(x.BookId))
                         .Select(x => x.BookName)
                         .ToList());
      start += batch;
    }
