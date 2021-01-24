    var connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=SSPI;app=LINQPad";
    Observable.Using(
            resourceFactoryAsync: async (ct) => await ConnectAsync(connectionString, ct),
            observableFactoryAsync: async (c, ct) => await QueryAsync(c, ct)
        )
        .Subscribe(
            onNext: r => Console.WriteLine(r),
            onError: e => Console.Error.WriteLine(e)
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
