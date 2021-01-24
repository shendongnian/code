    var connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=SSPI;app=LINQPad";
    Observable.Using(
            resourceFactoryAsync: async ct => await ConnectAsync(connectionString, ct),
            observableFactoryAsync: async (connection, ct) => await QueryAsync(connection, ct)
        )
        .Subscribe(
            onNext: Console.WriteLiner,
            onError: Console.Error.WriteLine
        );
    async Task<IObservable<string>> QueryAsync(SqlConnection c, CancellationToken ct = default)
    {
        var command = c.CreateCommand();
        command.CommandText = "select * from Categories as c order by c.CategoryId";
        var enumerableQuery = from IDataRecord record in await command.ExecuteReaderAsync(ct)
                              select (string)record["CategoryName"];
        return enumerableQuery.ToObservable();
    }
    
    async Task<SqlConnection> ConnectAsync(string cs, CancellationToken ct = default)
    {
        var connection = new SqlConnection(cs);
        await connection.OpenAsync(ct);
        return connection;
    }
