        public class Row
        {
            public string RowId { get; set; }
            public List<string> Columns { get; set; }
            public List<string> Values { get; set; }
            public string Status { get; set; }
        }
        public class RootRowObject
        {
            public List<Row> Rows { get; set; }
        }
      
        public class Article
        {
            public string Id { get; set; }
            public string Code { get; set; }
            public string Barcode { get; set; }
            public string SalesRep { get; set; }
            public string Price { get; set; }
        }
        string ConvertJson(string jsonRow)
        {
            RootRowObject rootRow = new 
                   JavaScriptSerializer().Deserialize<RootRowObject>(jsonRow);
            List<Article> articles = rootRow.Rows.Select(x => new Article
            {
                Code = x.Values[0],
                Barcode = x.Values[1],
                Id = x.RowId,
                Price = x.Values[3],
                SalesRep = x.Values[2]
            }).ToList();
            return new JavaScriptSerializer().Serialize(articles);
        }
