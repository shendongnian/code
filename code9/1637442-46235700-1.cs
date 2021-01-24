    public class Range<T> where T : IComparable<T>
    {
        public T Minimum { get; set; }
        public T Maximum { get; set; }
        // GetRandomNumber specific implementation, the field can have a different value for a specific `T`
        public static Func<Range<T>, T> GetRandomNumberHelper = (self) => throw new NotImplementedException("Not implemented for type " + typeof(T).FullName);
        public T GetRandomNumber()
        {
            return GetRandomNumberHelper(this);
        }
        
    }
    public class Program
    {
        public static void Main()
        {
            // Assign the delegate in a static constructor or a main
            Range<int>.GetRandomNumberHelper = self => new Random().Next(self.Minimum, self.Maximum);
        }
    }
