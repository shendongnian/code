    public class Test {
        public string First { get; set; }
        public string Second { get; set; }
        public override bool Equals(object obj) {
            return obj is Test && Equals((Test)obj);
        }
        protected bool Equals(Test other) {
            return string.Equals(First, other.First) && string.Equals(Second, other.Second);
        }
        public static bool operator ==(Test left, Test right) {
            return Equals(left, right);
        }
        public static bool operator !=(Test left, Test right) {
            return !Equals(left, right);
        }
    }
