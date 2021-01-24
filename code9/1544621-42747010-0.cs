    public class TestService
    {
        private static readonly List<string> list = new List<string>();
        
        public IEnumerable<string> List
        {
            get { return list; }
        }
        //list manipulation methods...
    }
