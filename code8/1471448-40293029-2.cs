    namespace WcfService1
    {
        public class Service1 : IService1
        {
            public List<US_States> GetAllStates()
            {
                List<US_States> result = new List<US_States>();
                result.Add(new US_States() { StateId = 1, StateName = "New York" });
                result.Add(new US_States() { StateId = 2, StateName = "Washington" });
                result.Add(new US_States() { StateId = 3, StateName = "Indiana" });
                return result;
            }
        }
    }
