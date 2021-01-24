    public abstract class DataFeederBase : IDataFeeder
        {
            public abstract DataTable GetData();
        }
    
        public class DataFeederByString : DataFeederBase
        {
            private string _sProc = string.Empty;
    
            public DataFeederByString(string sproc)
            {
                _sProc = sproc;
            }
    
            public override DataTable GetData()
            {
               //Implementation using sproc string
                return new DataTable();
            }
        }
    
        public class DataFeederByFixedPath : DataFeederBase
        {
            public override DataTable GetData()
            {
                //Implement using fixed path
                return new DataTable();
            }
        }
