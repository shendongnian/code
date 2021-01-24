    class SomeAttribute : System.Attribute
    {
        uint field1 = 1234567;
        public uint field2;
        public override int GetHashCode()
        {
            return (GetType(), field1, field2).GetHashCode();
        }
    }
