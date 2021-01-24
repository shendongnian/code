    if(command is DbCommand) 
    {
        var dbCommand = command as DbCommand;
        using (var dataReader = await dbCommand.ExecuteReaderAsync())
        {
            // iterate through the data reader converting a collection of Widgets (`IEnumerable<Widget>`)
        }
    }
