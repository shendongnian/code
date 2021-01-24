    class Program
    {
        const int flipCount = 40;
        const long counterMax = (long)1 << flipCount;
        static void Main(string[] args)
        {
            for (long flipSequence = 0; flipSequence < counterMax; flipSequence++)
            {
                DisplayFlips(flipSequence);
            }
        }
        private static readonly StringBuilder sb = new StringBuilder(flipCount);
        private static void DisplayFlips(long flipSequence)
        {
            sb.Clear();
            for (int i = 0; i < flipCount; i++)
            {
                sb.Append((flipSequence & 1) != 0 ? 'T' : 'H');
                flipSequence >>= 1;
            }
            Console.WriteLine(sb);
        }
    }
