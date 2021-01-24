    public class Model
    {
        readonly Stack<object> _stack = new Stack<object>();
        public void InsertRecord(object record)
        {
            _stack.Push(record);
        }
        public IEnumerable<object> Enumerate()
        {
            return _stack.AsEnumerable();
        }
    }
