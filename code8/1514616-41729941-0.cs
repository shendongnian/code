    static class Extensions
    {
        public static ValueReader<T> ReadValue<T>(this IEnumerable<T> source, out T value)
        {
            var result = new ValueReader<T>(source);
            result.ReadValue(out value);
            return result;
        }
    }
    class ValueReader<T>
    {
        IEnumerator<T> _enumerator;
        public ValueReader(IEnumerable<T> source)
        {
            if (source == null) source = new T[0];
            _enumerator = source.GetEnumerator();
        }
        public ValueReader<T> ReadValue(out T value)
        {
            bool hasNext = _enumerator.MoveNext();
            value = hasNext ? _enumerator.Current : default(T);
            return this;
        }
    }
    static class TestApp
    {
        public static void Main()
        {
            var remainders = new string[] { "test1", "test2", "test3" };
            string inputFileName, outputFileName, configFileName, willBeSetToNull;
            remainders
                .ReadValue(out inputFileName)
                .ReadValue(out outputFileName)
                .ReadValue(out configFileName)
                .ReadValue(out willBeSetToNull);
        }
    }
