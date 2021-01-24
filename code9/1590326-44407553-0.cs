    class MyClass: IEquatable<MyClass> {
        ...
        public bool Equals(MyClass obj)
        {
            if (obj == null)
            {
                return false;
            }
            return (this.Item1 == obj.Item1 && this.Item2 == obj.Item2);
        }
    }
