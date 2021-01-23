    public class TestClass
    {
        private int _length;
        public int Length
        {
            get
            {
                var localLength = _length;
                _length += 6;
                return localLength;
            }
            set { _length = value; }
        }
        public TestClass(int length)
        {
            this._length = length;
        }
    }
