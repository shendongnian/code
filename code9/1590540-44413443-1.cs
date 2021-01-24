    if (n != 0)
    {
        while (true)
        {
            if ((n & i) != 0)
            {
                lst.Add(i);
                n ^= i;
                if (n == 0)
                {
                    break;
                }
            }
            i <<= 1; // equivalent to i *= 2
        }
    }
