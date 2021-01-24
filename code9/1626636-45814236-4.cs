    public class SqlNameEscaper
    {
        private Dictionary<string, string> _quotedNames = new Dictionary<string, string>();
        private string _connectionString = string.Empty;
    
        public SqlNameEscaper(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public string GetSqlQuotedName(string name)
        {
            if (!_quotedNames.ContainsKey(name))
            {
                _quotedNames[name] = GetSqlQuotedNameFromSqlServer(name);
            }
    
            return _quotedNames[name];
        }
    
        private string GetSqlQuotedNameFromSqlServer(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT QUOTENAME(@name)", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    var result = command.ExecuteScalar();
    
                    return result.ToString();
                }
            }
        }
    }
