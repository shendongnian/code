    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    
    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString clrCarpma(double x, double y)
        {
            double z = x * y;
            string sz = z.ToString("R");
            return new SqlString(sz);
        }
    }
