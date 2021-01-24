    public abstract class DataFeederBase : IDataFeeder
    {
            public abstract DataTable GetData();
    }
    
    public class DataFeederByString : DataFeederBase
    {
            private string _storedProcedure = string.Empty;
    
            public DataFeederByString(string storedProcedure)
            {
                _storedProcedure = storedProcedure;
            }
    
            public override DataTable GetData()
            {
               //Implementation using stored procedure string
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
