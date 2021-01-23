        public interface IBaseServiceClass
        {
            IEnumerable<string> GetServiceData();
            IEnumerable<string> GetDashBoardData();
        }
    
        public interface IBaseServiceClass2 : IBaseServiceClass
        {
            IEnumerable<string> GetNewTypeOfData();
        }
    
    
        public class WebServiceClass2 : WebServiceClass, IBaseServiceClass2
        {
            public IEnumerable<string> GetNewTypeOfData()
            {
                return Enumerable.Empty<string>();
            }
        }
    
        public class WebServiceClass : IBaseServiceClass
        {
            public IEnumerable<string> GetServiceData()
            {
                List<string> MyList = new List<string>();
                return MyList;
            }
    
            public IEnumerable<string> GetDashBoardData()
            {
                List<string> MyList = new List<string>();
                return MyList;
            }
        }
