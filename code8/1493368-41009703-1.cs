    class MyComparer : IEqualityComaprer<MyClass> {
        public bool Equals(MyClass a, MyClass b) {
            if (Object.Equals(a, null)) return Object.Equals(b, null);
            if (Object.Equals(b, null)) return false;
            return a.name == b.name;
        }
        public int GetHashCode(MyClass obj) => obj.name.GetHashCode();
    }
