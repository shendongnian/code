    public struct Grade: IEquatable<Grade>
    {
        private int innerValue;
        private int InnerValue => isInitialized ? innerValue : 1;
        private readonly bool isInitialized;
        private Grade(int value)
        {
            if (value < 1 || value > 5)
                throw new OverflowException();
            innerValue = value;
            isInitialized = true;
        }
        public static implicit operator Grade(int i) => new Grade(i);
        public static explicit operator int(Grade g) =>  g.InnerValue;
        public override bool Equals(object obj) => obj is Grade && Equals((Grade)obj);
        public bool Equals(Grade other) => InnerValue == other.InnerValue;
        public override int GetHashCode() => InnerValue.GetHashCode();
        public override string ToString() => InnerValue.ToString();
        public static bool operator ==(Grade left, Grade right) => left.Equals(right);
        public static bool operator !=(Grade left, Grade right) => !left.Equals(right);
    }
