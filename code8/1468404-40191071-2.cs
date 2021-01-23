    public JsonResult SearchResults(IEnumerable<string> searchKeys, int page)
    {
        var data = dbContext.MyTable.Where(x => searchKeys.Any(serachKey => x.Title.Contains(searchKey))).OrderByDescending(x => x.CreatedDate):
        return GetDataPage(data, page);
    }
