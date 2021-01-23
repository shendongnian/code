        public abstract class BaseServiceClass
        {
            public abstract IEnumerable<string> GetServiceData();
            public abstract IEnumerable<string> GetDashBoardData();
        }
    
        public abstract class BaseServiceClass2 : BaseServiceClass
        {
            public abstract IEnumerable<string> GetNewTypeOfData();
        }
    
    
        public class WebServiceClass2 : BaseServiceClass2
        {
            private BaseServiceClass adaptee;
    
            WebServiceClass2(BaseServiceClass adaptee)
            {
                this.adaptee = adaptee;
            }
    
            public override IEnumerable<string> GetDashBoardData()
            {
                return adaptee.GetDashBoardData();
            }
    
            public override IEnumerable<string> GetNewTypeOfData()
            {
                return Enumerable.Empty<string>();
            }
    
            public override IEnumerable<string> GetServiceData()
            {
                return adaptee.GetServiceData();
            }
        }
