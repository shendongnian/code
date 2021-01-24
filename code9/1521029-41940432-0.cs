     public class MyClass<T>
        {
            private readonly Dictionary<string, T> _data = new Dictionary<string, T>();
    
            public MyClass( Dictionary<string, T> newData)
            {
                _data = newData;
            }
    
            public Dictionary<string, T> Data
            {
                get { return _data;}
            }
           
        }
