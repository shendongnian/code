    public class OracleStoreFactory : IFactory<OracleStore>
    {
        public OracleStore CreateInstance()
        {
            return new OracleStore();
        }
    }
