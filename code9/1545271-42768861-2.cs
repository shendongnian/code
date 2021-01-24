    public class InputComparer : IEqualityComparer<Input>
    {
        public bool Equals(Input a, Input b)
        {
            return a.variableA == b.variableA
                && a.variableB == b.variableB
                && ... and so on
        }
        
        public int GetHashCode(Input a)
        {
            return a.GetHashCode();
        }
    }
