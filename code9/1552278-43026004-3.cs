    public class OracleStore : CacheStoreAdapter
    {
        public override object Load(object key)
        {
            using (var con = new OracleConnection
            {
                ConnectionString = "User Id=<username>;Password=<password>;Data Source=<datasource>"
            })
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM MyTable WHERE ID=@id";
                cmd.Parameters.Add("@id", OracleType.Int32);
                cmd.Parameters["@id"].Value = key;
                using (var reader = cmd.ExecuteReader())
                {
                    // Read data, return as object
                }
            }
        }
        public override void Write(object key, object val)
        {
            oracleDb.UpdateRow(key, val);
        }
        public override void Delete(object key)
        {
            oracleDb.DeleteRow(key);
        }
    }
