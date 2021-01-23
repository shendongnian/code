    public static async Task<IEnumerable<dynamic>> GetProfitMargin(List<int> QuoteIds)
        {
            using (var conn = new SqlConnection(new MYContext().Database.Connection.ConnectionString))
            {   
               string sqlQuery = "SELECT SellingPrice, MarkupPercent, MarkupAmount FROM ProfitMargins WHERE QuoteId in @QuoteId";
                {
                    IEnumerable<dynamic> profitMargin =  await conn.QueryAsync<dynamic>(sqlQuery
                       , new { QuoteId = new[] { 1, 2, 3, 4, 5 } });                    
                }
