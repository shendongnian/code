    public async Task ExecuteAsync(string query, Func<IDataReader, Task> onExecute, params DataParameter[] parameters)
    {
        using(var command = builder.BuildCommand(query))
        {
            foreach(var parameter in parameters)
                command.AddParameter(parameter);
            if(!connection.IsOpen)
                connection.Open();
            using(var reader = await command.ExecuteAsync())
                await onExecute(reader);
        }
    }
