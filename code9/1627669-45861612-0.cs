    public async Task AddPerson(string name, string surname)
    {
       const string sql = "insert into Persons(Name, Surname) values(@Name, @Surname)";  
       using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
       using (var connection = await _connectionProvider.OpenAsync()) //Or however you get the connection
       {
         await connection.ExecuteAsync(sql, new{name, surname});
         tran.Complete();
       }
    }
