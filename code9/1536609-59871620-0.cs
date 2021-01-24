    public partial class MyDbContext : System.Data.Entity.DbContext
    {
        public string GetTableName(Type entityType)
        {
            var sql = Set(entityType).ToString();
            var regex = new Regex(@"FROM \[dbo\]\.\[(?<table>.*)\] AS");
            var match = regex.Match(sql);
            return match.Groups["table"].Value;
        }
    
        public string[] GetColumnName(Type entityType)
        {
            var strs = new List<string>();
            var sql = Set(entityType).ToString();
            var regex = new Regex(@"\[Extent1\]\.\[(?<columnName>.*)\] AS");
            var matches = regex.Matches(sql);
            foreach (Match item in matches)
            {
                var name = item.Groups["columnName"].Value;
                strs.Add(name);
            }
            return strs.ToArray();
        }
    }
