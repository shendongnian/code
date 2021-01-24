    public class XConnector : IXConnector
    {
        private static IXConnector _instance = new XConnector();
        private XConnector()
        {
        }
        public static IXConnector Current
        { 
           get
           {
               return _instance;
           }
           set 
           {
               // Think about thread-safety
               // Check for null?
               _instance = value;
           }
        }
        public async Task<XConnector> GetData(XConnector con)
        {
        }
    }
