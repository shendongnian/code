    public static IEnumerable<int> BoyerMooreHorspoolIndexesOf(byte[] haystack, byte[] needle)
    {
        if (haystack == null)
            throw new ArgumentNullException("haystack");
        if (needle == null)
            throw new ArgumentNullException("needle");
        int haystackLength = haystack.Length;
        int needleLength = needle.Length;
        if ((haystackLength == 0) || (needleLength == 0) || (needleLength > haystackLength))
            yield break;
        var misses = new int[256];
        for (var i = 0; i < 256; ++i)
            misses[i] = needleLength;
        var lastneedleByte = needleLength - 1;
        for (var i = 0; i < lastneedleByte; ++i)
            misses[needle[i]] = lastneedleByte - i;
        var index = 0;
        while (index <= (haystackLength - needleLength))
        {
            for (int i = lastneedleByte; haystack[index + i] == needle[i]; --i)
            {
                if (i == 0)
                {
                    yield return index;
                    break;
                }
            }
            index += misses[haystack[index + lastneedleByte]];
        }
    }
