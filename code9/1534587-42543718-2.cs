     public class MyDataClass {
        string connectionString;
        private Database database;
        public MyDataClass(DbContext context) {
            this.database = context.Database;
            connectionString = database.Connection.ConnectionString;
        }
        public DataTable GetData1(int Id) {
            var dt = new DataTable();
            using (var sqlcon = new SqlConnection(connectionString)) {
                using (var cmd = new SqlCommand("spGetData1", sqlcon)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id", Value = Id });
                    using (var da = new SqlDataAdapter(cmd)) {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public DataTable GetData2(int Id) {
            var dt = new DataTable();
            using (var sqlcon = new SqlConnection(connectionString)) {
                using (var cmd = new SqlCommand("spGetData2", sqlcon)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id", Value = Id });
                    using (var da = new SqlDataAdapter(cmd)) {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
