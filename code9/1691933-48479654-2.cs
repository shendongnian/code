    public class SomeClassThatMultipleThreadsAccess
    {
        private readonly object _lockObject = new object();
        private bool _isPopulated = false;
        private readonly List<Something> _list;
        public IReadOnlyList<Something><Something> MethodThatGetsCalledConcurrently()
        {
            if (_isPopulated) return;
            lock (_lockObject)
            {
                if (_isPopulated) return;
                PopulateTheList();
                _isPopulated = true;
            }
            return _list.AsReadOnly();
        }
        private void PopulateTheList()
        {
            // this takes longer, only run it once
        }
    }
