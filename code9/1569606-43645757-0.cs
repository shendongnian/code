    public Dictionary<string, string> GetRegistry()
            {
    
    
                var table = this.connection.Table<Registry>();
                Dictionary<string, string> RegistryItems = new Dictionary<string, string>();
    
                var ages = table.Select(X => x.Name == "Age").ToList();
    
            }
