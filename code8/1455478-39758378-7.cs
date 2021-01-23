    public class ByteArrayComparer : IComparer<byte[]>
    {
        public int Compare(byte[] first, byte[] second)
        {
            if (first == null && second == null)
                return 0;
            else if (first == null)
                return -1;
            else if (second == null)
                return 1;
            else
            {
                // find the minimum length of the both arrays
                var length = first.Length > second.Length ? second.Length : first.Length;
                for (var index = 0; index < length; index++)
                {
                    if (first[index] > second[index])
                        return 1;
                    if (second[index] > first[index])
                        return -1;
                }
            }
            return 0;
        }
    }
