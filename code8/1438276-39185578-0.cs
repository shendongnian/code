    public class Key<T>
    {
        public T Value { get; private set; }
        private Key( ) { }
        public static Key<T> Make(T inVal)
        {
            var inT = inVal.GetType();
            if (inT != typeof(int) && inT != typeof(string))
                throw new TypeAccessException("Wrong type");
            return new Key<T> {Value = inVal};
        }
    }
