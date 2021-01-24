    public static class Helper
    {
        static BigInteger[] factors = Enumerable.Range(0, 19).Select(i=> BigInteger.Pow(10, i)).ToArray();
        public static BigInteger ParseFast(string str)
        {
            var result = new BigInteger(0);
            var n = str.Length;
            var hasSgn = str[0] == '-';
            int j;
            for (var i = hasSgn ? 1 : 0; i < n; i += j - i)
            {
                long gr = 0;
                for (j = i; j < i + 18 && j < n; j++)
                {
                    gr = gr * 10 + (str[j] - '0');
                }
                result = result * factors[j-i]+ gr;
                
            }
            if (hasSgn)
            {
                result = BigInteger.MinusOne * result;
            }
            return result;
        }
    }
