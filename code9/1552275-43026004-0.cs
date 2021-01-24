    public class OracleStore : CacheStoreAdapter
    {
        public override object Load(object key)
        {
            return oracleDb.GetRow(key);
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
