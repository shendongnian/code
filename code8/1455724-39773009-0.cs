    public class IntBox
    {
        public int Value;
    
        public IntBox(int value)
        {
            Value = value;
        }
    
        public static implicit operator IntBox(int value)
        {
            return new IntBox(value);
        }
    }
