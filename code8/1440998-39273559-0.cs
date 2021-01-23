    public class Example<T>
    {
         internal Example() { } //disallow users from instantiating this class
          ...
    }
    public class Example
    {
        public const int Constant = ...
        public static Example<T> Create<T>() { return new ... }
    }
