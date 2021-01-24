    static bool almostIncreasingSequence(int[] sequence)
    {
        int erasedElements = 0;
        for (int i = 0, j = 1; j < sequence.Length; j++)
        {
            if (sequence[i] >= sequence[j])
            {
                erasedElements += 1;
                if (j > 1)
                {
                    continue;
                }
            }
            i = j;
        }
        return (erasedElements <= 1);
    }
