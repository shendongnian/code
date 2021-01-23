    public class Base<T>
    {
        T _data;
    
        public class Data // Note that it's a class now instead of a struct
        {
            public T _data;
        }
    }
    
    public class Custom : Base<int>
    {
        public class DataCustom : Base<int>.Data
        {
            public float _bla;
            public bool _bla2;
        }
    
        public void BlaBla()
        {
            DataCustom data = new DataCustom();
    
            int dataBase = data._data; // now works
            float bla = data._bla;
            bool bla2 = data._bla2;
        }
    }
