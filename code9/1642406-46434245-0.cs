    public class RightOperandValue : IEquatable<RightOperandValue> 
    {
        public string Value { get; set; }
        public string DisplayName { get; set; }
        
        public bool Equals(RightOperandValue other)
        {
            if (Value == other.Value
                && DisplayName == other.DisplayName)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hashValue = Value == null ? 0 : Value.GetHashCode();
            int hashDisplayName = DisplayName == null ? 0 : DisplayName.GetHashCode();
            return hashValue ^ hashDisplayName;
        }
    }
