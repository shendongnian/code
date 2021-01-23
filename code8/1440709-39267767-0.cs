    public IHttpActionResult GetProduct(int campaignID, int productID)
    {
        var so = new SearchOptions(campaignID)
        {
            ProductID = productID
        };
        var result = SearchManager.Search(so);
        if (result == null || result.Rows.Count == 0)
            return NotFound();
        
        var row = result.Rows[0];
        return Ok(row.Table.Columns
            .Cast<DataColumn>()
            .ToDictionary(c => c.ColumnName, c => row[c]));
    }
