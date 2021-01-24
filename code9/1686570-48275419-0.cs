    abstract class FormatAttribute : Attribute {
        public abstract string Format(string value);
    }
    class UpperCaseAttribute : FormatAttribute {
        public override string Format(string value) => value.ToUpper();
    }
