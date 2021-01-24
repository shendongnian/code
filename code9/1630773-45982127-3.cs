    string content = "";
    var files = Directory.EnumerateFiles(@"C:\Users\Projects", "*.csv");
    foreach (string file in files)
        content += System.IO.File.ReadAllText(file) + Environment.NewLine;
    
    using(TextReader sr = new StringReader(content))
    {
       var csv = new CsvReader(sr);
          csv.Configuration.RegisterClassMap<TokenMap>();
          var records = csv.GetRecords<Token>();
    }
      
    
    
    
    public class TokenMap : CsvClassMap<Token>
    {
        public TokenMap()
        {
            Map(m => m.Product_name );
            Map(m => m.Product_Version);
            Map(m => m.Userid);
            Map(m => m.User_name);
            Map(m => m.Machine_name);
            Map(m => m.Server_name);
            Map(m => m.Tokens_used);
            Map(m => m.Use_count);
        }
    }
