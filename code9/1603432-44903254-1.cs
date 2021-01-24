     public void AddParameters(SqlParameter[]  parameters)
        {
            if (parameters == null)
                return;
            sqlCommand.Parameters.AddRange(parameters);
            
        }
