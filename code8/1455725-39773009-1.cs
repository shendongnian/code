    public class IntBox
    {
        public int Value;
    
        public IntBox(int value)
        {
            Value = value;
        }
    
        public static implicit operator IntBox(Int64 value)
        {
            return new IntBox(value);
        }
    }
