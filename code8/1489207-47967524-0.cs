    internal IDbCommand SetupCommand(IDbConnection cnn, Action<IDbCommand, object> paramReader)
        {
          IDbCommand command = cnn.CreateCommand();
          Action<IDbCommand> init = CommandDefinition.GetInit(command.GetType());
          if (init != null)
            init(command);
          if (this.Transaction != null)
            command.Transaction = this.Transaction;
          command.CommandText = this.CommandText;
          if (this.CommandTimeout.HasValue)
          {
            command.CommandTimeout = this.CommandTimeout.Value;
          }
          else
          {
            int? commandTimeout = SqlMapper.Settings.CommandTimeout;
            if (commandTimeout.HasValue)
            {
              IDbCommand dbCommand = command;
              commandTimeout = SqlMapper.Settings.CommandTimeout;
              int num = commandTimeout.Value;
              dbCommand.CommandTimeout = num;
            }
          }
          System.Data.CommandType? commandType = this.CommandType;
          if (commandType.HasValue)
          {
            IDbCommand dbCommand = command;
            commandType = this.CommandType;
            int num = (int) commandType.Value;
            dbCommand.CommandType = (System.Data.CommandType) num;
          }
          if (paramReader != null)
            paramReader(command, this.Parameters);
          return command;
        }
