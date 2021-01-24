    public class InstanceClass
    {
        private List<int> _source;
        private int offset;
        public int this[int index] // you use "this"
        {
            get => _source[index + offset]
            set => _source[index + offset] = value;
        }
        public void Method()
        {
            var first = this[0]; // must use "this" to refer to indexer for this class.
        }
    }
