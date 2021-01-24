    #pragma warning disable 0693
    public class A<T> where T : struct
    {
        public class B<T> where T : class
        {
        }
    }
    #pragma warning restore 0693
