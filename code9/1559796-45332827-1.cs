    class TestObject
    {
        public static bool operator ==(TestObject lhs, TestObject rhs) => false;
        public static bool operator !=(TestObject lhs, TestObject rhs) => false;
    }
