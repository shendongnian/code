    public static string MapDataTypes(SqlDbType sqlDataType)
    {
        switch (sqlDataType)
        {
            case SqlDbType.Int:
                return "INT";
            case SqlDbType.VarChar:
                return "TEXT(80)";
            ... AND SO ON FOR EVERY POSSIBLE TYPE
       }
    }
