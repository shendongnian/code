    class Wrapper
    {
        private dynamic _data;
        public string Value {  get { return _data.Value; } }
        public Wrapper(dynamic data)
        {
            _data = data;
        }
    }
