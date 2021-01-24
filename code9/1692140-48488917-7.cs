    #pragma warning disable 0693
    class A<T> where T : struct
    {
        class B<T> where T : class
        {
        }
    }
    #pragma warning restore 0693
