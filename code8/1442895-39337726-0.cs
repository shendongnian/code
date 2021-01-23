    class IntHolder : IComparable<IntHolder>
    {
        public int SomeInt { get; set; }
    
        public int CompareTo(IntHolder  other)
        {
            return SomeInt.CompareTo(other.SomeInt);
        }
    }
