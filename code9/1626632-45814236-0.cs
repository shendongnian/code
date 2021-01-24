    private Dictionary<string, string> _quotedNames = new Dictionary<string, string>();
    
    private string GetSqlQuotedName(string name)
    {
        if (!_quotedNames.ContainsKey(name))
        {
            _quotedNames[name] = GetSqlQuotedNameFromSqlServer(name);
        }
    
        return _quotedNames[name];
    }
    
    private string GetSqlQuotedNameFromSqlServer(string name)
    {
        /// Code here to use your Data access method of choice to basically execute
        /// SELECT QUOTENAME(name) and return it
    }
