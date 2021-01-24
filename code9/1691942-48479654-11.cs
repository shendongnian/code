    public class SomeClassThatMultipleThreadsAccess
    {
        private readonly Lazy<List<Something>> _list 
            = new Lazy<List<Something>>(PopulateTheList);
        public IReadOnlyList<Something> MethodThatGetsCalledConcurrently()
        {
            return _list.Value;
        }
        private static List<Something> PopulateTheList()
        {
            var list = new List<Something>();
            // populate it
            return list;
        }
    }
