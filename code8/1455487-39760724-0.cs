    public class CompareByteArrays : IComparer<byte[]>
    {
        public int Compare(byte[] a1, byte[] a2)
        {
            int shorterLength = a1.Length < a2.Length ? a1.Length : a2.Length;
            for(int i = 0; i < shorterLength; i++)
            {
                if(a1[i] < a2[i])
                {
                    return -1;
                }
                else if(a1[i] > a2[i])
                {
                    return 1;
                }
            }
            return a1.Length.CompareTo(a2.Length);
        }
    }
