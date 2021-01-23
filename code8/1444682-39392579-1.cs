    class MyObject<T> {
        public MyObject(T someEnum) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum) 
                throw new ArgumentException("Not an enum");
            ID = Convert.ToInt32(someEnum);
        }
    }
