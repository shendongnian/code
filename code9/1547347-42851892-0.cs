    public static SqlCommand WithParameter(this SqlCommand sqlCommand, SqlParameter parameter)
        {
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }
