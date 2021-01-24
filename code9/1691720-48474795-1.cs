    [assembly: Dependency(typeof(DataHandler))]
    namespace provisioning.ios
    {
        public class DataHandler: IDataHandler
        {
            public DataHandler()
            {
            }
        
            public string GetSomeStringValue()
            {
                return "Some string value or whatever";
            }
        }
    }
