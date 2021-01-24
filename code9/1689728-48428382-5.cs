    private static int IndexOf2(byte[] input, byte[] pattern)
    {
        byte firstByte = pattern[0];
        int  index     = -1;
    
        if ((index = Array.IndexOf(input, firstByte)) >= 0)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (index + i  >= input.Length ||
                    pattern[i] != input[index + i]) return -1;
            }
        }
    
        return index;
    }
