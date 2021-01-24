     public void AddParameters(List<SqlParameter> parameters)
        {
            if (parameters == null)
                return;
            sqlCommand.Parameters.AddRange(parameters.ToArray());
            
        }
