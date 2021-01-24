    public class A : IFormattable
    {
        public string Aa { get; } = "123";
        public int Bb { get; } = 5;
    
        public A(){ }
    
        public A(string aa, int bb)
        {
            this.Aa = aa;
            this.Bb = bb;
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"aa={Aa} bb={Bb}";
        }
    
        public static explicit operator A(string strA)  
        {
            if (strA == null) return null;
            if (!strA.Contains("aa=") || !strA.Contains(" bb=")) return null;
            string[] parts = strA.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2 || !parts[0].StartsWith("aa=") || !parts[1].StartsWith("bb=")) return null;
    
            string aa = parts[0].Substring(3);
            string bb = parts[1].Substring(3);
            int bbInt;
            if (!int.TryParse(bb, out bbInt)) return null;
            A a = new A(aa, bbInt);
            return a;
        }
    }
