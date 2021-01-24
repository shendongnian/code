    public class MaxSequenceFinder
    {
        public int FindBestCollatzSequence(int start, int count)
        {
            return Enumerable.Range(start, count).Max(n => CalcCollatzSequence((long)n));
        }
        private int CalcCollatzSequence(long n)
        {
            int sequenceLength = 0;
            
            do
            {
                n = CalcNextTerm(n);
                sequenceLength++;
            }
            while (n != 1);
            return sequenceLength;
        }
        private long CalcNextTerm(long previousTerm)
        {
            return previousTerm % 2 == 0 ? previousTerm / 2 : previousTerm * 3 + 1;
        }
    }
