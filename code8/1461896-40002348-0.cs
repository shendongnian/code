    IDbDataParameter param = command.CreateParameter();
    // Set the parameter properties
    param.ParameterName = ParameterName;
        if (!m_inferType)
        {
            param.DbType = DbType;
        }
        if (Precision != 0)
        {
            param.Precision = Precision;
        }
        if (Scale != 0)
        {
            param.Scale = Scale;
        }
        if (Size != 0)
        {
            param.Size = Size;
        }
        // Add the parameter to the collection of params
        command.Parameters.Add(param);
