    public class MyStructComparer : IEqualityComparer<MyStruct>
    {
        public bool Equals(MyStruct x, MyStruct y)
        {
            // ...
        }
        public int GetHashCode(MyStruct obj)
        {
            // ...
        }
    }
