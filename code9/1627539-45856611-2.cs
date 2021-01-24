    public struct MyStruct: IEquatable<MyStruct>
    {
        public int Id;
       
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is MyStruct && Equals((MyStruct)obj);
        }
        public bool Equals(MyStruct other)
        {
            return this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
