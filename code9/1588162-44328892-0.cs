    public interface IEquatable<T>
    {
        bool Equals(T other);
    }
    public class MyInt : IEquatable<MyInt> //you need an actual implementor of IEquatable<T>
    {
        public int Value { get; set; }
        public bool Equals(MyInt other)
        {
            return Value.Equals(other);
        }
    }
    class Test
    {
        public static bool IsEqual<T>(T a, T b) where T : IEquatable<T>
        {
            // Ensure your Equals implementation is used
            return a.Equals(b);
        }
    }
    var x = new MyInt { Value = 2 };
    var y = new MyInt { Value = 3 };
    Test.IsEqual(x, y);
