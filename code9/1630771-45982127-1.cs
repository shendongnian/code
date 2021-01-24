      var csv = new CsvReader( new TextReader("file.csv"));
      csv.Configuration.RegisterClassMap<TokenMap>();
      var records = csv.GetRecords<Token>();
    
    
    
    public class TokenMap : CsvClassMap<Token>
    {
        public TokenMap()
        {
            Map(m => m.Id);
            Map(m => m.Names).ConvertUsing(row =>
            {
                var list = new List<string>();
                list.Add(row.GetField( 1 ));
                list.Add(row.GetField( 2 ));
                list.Add(row.GetField( 3 ));
                return list;
            });
        }
    }
