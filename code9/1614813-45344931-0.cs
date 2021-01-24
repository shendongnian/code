    public class LengthAttribute : ValidationAttribute {
        readonly int length;
    
        public LengthAttribute(int length) {
            this.length = length;
        }
    
        public override bool IsValid(object value) {
            if (value is ICollection == false) { return false; }
            return ((ICollection)value).Count == length;
        }
    }
