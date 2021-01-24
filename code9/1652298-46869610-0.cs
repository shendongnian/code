    public interface ISQLReader
        {
            string GetData();
        }
    
        public interface IOracleReader
        {
            string GetData();
        }
    
        public abstract class Reader
        {
            protected void CommonFunctionaility()
            {
    
            }
        }
        public class MSSQLReader : Reader, ISQLReader
        {
            public string GetData()
            {
                return "MSSQL";
            }
        }
    
        public class OracleReader : Reader, IOracleReader
        {
            public string GetData()
            {
                return "Oracle";
            }
        }
    
        public interface IReaderFactory
        {
            OracleReader CreateOracleReader();
            MSSQLReader CreateMSSQLReader();
        }
    
        public class ReaderFactory : IReaderFactory
        {
            public MSSQLReader CreateMSSQLReader() => new MSSQLReader();
    
            public OracleReader CreateOracleReader() => new OracleReader();
        }
    
        public class ReaderClient
        {
            private IReaderFactory _factory;
            public ReaderClient(IReaderFactory factory)
            {
                this._factory = factory;
            }
        }
