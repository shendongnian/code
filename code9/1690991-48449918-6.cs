    class Program
    {
        static void Main(string[] args)
        {
            var pow = new BigInteger(12);
            var value = Math.Pow(2, (int)pow);
            var lastDigit = LastDigit(pow.ToByteArray());
        }
        public static int LastDigit(byte[] n)
        {
            var last = n[n.Length - 1] %4;
            return (int)Math.Pow(2, last) + ((last == 0 && !(n.Length == 1 && n[0] == 0)) ? 5 : 0);
        }
    }
