    namespace WcfService2
    {
        public class Service1 : BaseService, IService1
        {
            public string GetData(int value)
            {
                var d = 100/value;
                return string.Format("You entered: {0}", value);
            }
        }
    }
