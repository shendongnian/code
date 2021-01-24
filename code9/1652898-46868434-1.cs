    using System;
    using System.Data.SqlClient;
    namespace SqlScriptAsAResource
    {
        internal static class SqlUtilities
        {
            public static readonly String SqlScriptValue = "SELECT * FROM Table1;";
            public static readonly SqlCommand Commadn = new SqlCommand("SELECT * FROM Table1;");
        }
    }
