    public class Input : IComparable<Input> 
    {
        ...
        public int Compare(Input other)
        {
            int a = this.VariableA ^ this.VariableB;
            int b = other.VariableA ^ other.VariableB;
            return a.Compare(b);
        }
    }
