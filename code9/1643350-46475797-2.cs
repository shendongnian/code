    public sealed class Coin
    {
        internal Coin(CoinColor color, CoinLetter letter)
        {
            Color = color;
            Letter = letter;
        }
        public CoinColor Color { get; }
        public CoinLetter Letter { get; }
        private bool Equals(Coin other)
        {
            return Color == other.Color && Letter == other.Letter;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Coin) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Color * 397) ^ (int) Letter;
            }
        }
        public static bool operator ==(Coin left, Coin right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Coin left, Coin right)
        {
            return !Equals(left, right);
        }
        public override string ToString()
        {
            return $"{nameof(Color)}: {Color}, {nameof(Letter)}: {Letter}";
        }
    }
