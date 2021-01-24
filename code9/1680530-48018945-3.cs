    int val = 0;
    var pagedQAs = getAllQAs
        .Where(qa => qa.Show)
        .ToList()
        .OrderByDescending(qa => int.TryParse(qa.Code,out val) ? val : Int32.MaxValue)
        .Skip((page - 1) * pageSize).Take(pageSize)
        .Select(QAViewModels.Set)
        .ToList();
