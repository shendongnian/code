    public IList<Employee> SortBy(string lastName, string sortByColumnA, bool isDescendingA, string sortByColumnB, bool isDescendingB)
    {
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumnA))
            throw new ArgumentOutOfRangeException(nameof(sortByColumnA), "Unknown column " + sortByColumnA);
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumnB))
            throw new ArgumentOutOfRangeException(nameof(sortByColumnB), "Unknown column " + sortByColumnB);
        var sortDirectionA = isDescendingA ? " DESC " : "";
        var sortDirectionB = isDescendingB ? " DESC " : "";
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Select(db.From<Employee>().Where(x => x.LastName == lastName)
                .OrderBy(sortByColumnA + sortDirectionA + "," + sortByColumnB + sortDirectionB)).ToList();
        }
    }
