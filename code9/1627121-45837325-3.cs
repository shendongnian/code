    public async Task<IEnumerable<Widget>> ReadAllAsync(
        System.Data.IDbConnection databaseConnection,
        System.Data.IDbTransaction databaseTransaction)
    {
        var commandText = "SELECT WidgetId, Name FROM Widget";
    
        // _databaseCommandFactory.Create returns an IDbCommand
        var command = this._databaseCommandFactory.Create(databaseConnection, databaseTransaction, commandText);
    
        using (var dataReader = command.ExecuteReader())
        {
            // iterate through the data reader converting a collection of Widgets (`IEnumerable<Widget>`)
        }
    }
