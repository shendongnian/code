     public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
           
            foreach (DbParameter parameter in command.Parameters)
            {
                command.CommandText = StringExtendsionsMethods.ReplaceWholeWord(command.CommandText, parametru.ParameterName, "'" + parametru.Value.ToString() + "'");
            }
    
    
            string filterR = command.CommandText.Replace('\r', ' ');
            string filterN = faraR.Replace('\n', ' ');
            string cleanSQLCommand = filterN.Replace('`', ' ');
    
    
    
            Write(string.Format(cleanSQLCommand));
        }
