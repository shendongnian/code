    class FieldValue
    {
        private object data;
        private Type type;
        public object Data
        {
            get { return data; }
            set
            {
                data = value;
                type = value.GetType();
            }
        }
        public Type Type
        {
            get { return type; }
        }
    }
