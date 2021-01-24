    public List<MyClass> GetData(int Id, IEnumerable<string> state)
    {
        using (var dataContext = new DataContext(_connectionString))
        {
            var stateParameterNumbers = Enumerable.Range(1, state.Count())
                .Select(i => string.Format("{{{0}}}", i));
        
            var stateParameterString = string.Join(",", stateParameterNumbers);
        
            string query = "SELECT * FROM table WHERE Id ={0} AND state IN (" + stateParameterString + ")";
            return dataContext.ExecuteQuery<MyClass>(query, new object[] { Id }.Concat(state).ToArray()).ToList();
        }
    }
