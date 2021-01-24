    class Program
    {
        static void Main(string[] args)
        {
            string orclString = "Data Source=orclservername:/XE;Persist Security Info=True;User Id = \"Jonathan\"; Password=safepassword";
            string sqlString = "Integrated Security = SSPI; Initial Catalog = sqldemo; Data Source =sqlservername";
            using (var orclConn = new OracleConnection(orclString))
            {
                using (var orclCmd = new OracleCommand("SELECT * FROM yourschema.yourorcltable", orclConn))
                {
                    DataTable dT = new DataTable();
                    var dA = new OracleDataAdapter(orclCmd);
                    dA.Fill(dT);
                    using (SqlConnection sqlConn = new SqlConnection(sqlString))
                    {
                        sqlConn.Open();
                        using (var bC = new SqlBulkCopy(sqlConn))
                        {
                            bC.DestinationTableName = "yoursqltable";
                            bC.WriteToServer(dT);
                        }
                    }
                }
            }
        }
    }
