    class MyObject<T> {
        public MyObject(T someEnum) where T : Enum
        {
            ID = Convert.ToInt32(someEnum);
        }
    }
