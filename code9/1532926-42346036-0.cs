    public IntBoolValue this[string index]
    {
        get
        {
            // Here you need to check whether you can find an entry in permissions or in constraints. Then return the found value.
            return new IntBoolValue(permissions.Where (p => p.name == index).First ().allowed);
        }
    }
    // ------------------
    
    internal struct IntBoolValue
    {
        internal int internalInt;
        internal bool internalBool;
    
        public IntBoolValue(int value) { this.internalInt = value; }
        public IntBoolValue(bool value) { this.internalBool = value; }
        
        public static implicit operator bool(IntBoolValue value)
        {
            return value.internalBool;
        }
        
        public static implicit operator int(IntBoolValue value)
        {
            return value.internalInt;
        }
    }
