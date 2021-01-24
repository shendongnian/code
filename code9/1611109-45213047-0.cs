    public async Task ExecuteAsync(string query, Action<IDataReader> onExecute, params DataParameter[] parameters)
    {
        using(var command = builder.BuildCommand(query))
        {
            foreach(var parameter in parameters)
                command.AddParameter(parameter);
            if(!connection.IsOpen)
                connection.Open();
            await Task.Run(async () =>
            {
                using(var reader = await command.ExecuteAsync())
                    if(await reader.ReadAsync())
                        onExecute(reader);
            });
        }
    }
