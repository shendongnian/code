    public static string MapDataTypes(SqlDbType sqlDataType, int size)
    {
        switch (sqlDataType)
        {
            case SqlDbType.Int:
                return "INT";
            case SqlDbType.VarChar:
                return "TEXT(" + size + )";
            .....
       }
    }
