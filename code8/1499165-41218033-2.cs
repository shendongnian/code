    public struct Key
    {
        public char KeyChar;
        public int Pos;
        public override int GetHashCode()
        {
            return (int)KeyChar + Pos << 16;
        }
        public override bool Equals(object obj)
        {
            if (!obj is Key) return false;
            var other = (Key)obj;
            return KeyChar == other.KeyChar && Pos == other.Pos;
        }
    }
