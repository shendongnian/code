    string sqlQuery = "SELECT SellingPrice, MarkupPercent, MarkupAmount FROM ProfitMargins WHERE QuoteId in @QuoteId";
    
    using(var conn = new SqlConnection(myConnString)
    {
        var profitMargin = conn.Query<dynamic>(sqlQuery
           , new { QuoteId = new[] { 1, 2, 3, 4, 5 } });
    
    }
