    public static int IndexOf(byte[] arrayToSearchThrough, byte[] patternToFind)
    {
        if (patternToFind.Length > arrayToSearchThrough.Length)
            return -1;
        for (int i = 0; i < arrayToSearchThrough.Length - patternToFind.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < patternToFind.Length; j++)
            {
                if (arrayToSearchThrough[i + j] != patternToFind[j])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                return i;
            }
        }
        return -1;
    }
 
