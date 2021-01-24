        public static IEnumerable<int> FindByteSequenceArray(byte[] content, byte[] sequenceToFind)
        {
            return BoyerMooreHorspoolIndexesOf(content, sequenceToFind);
        }
        public static IEnumerable<int> BoyerMooreHorspoolIndexesOf(byte[] value, byte[] pattern)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (pattern == null)
                throw new ArgumentNullException("pattern");
            int valueLength = value.Length;
            int patternLength = pattern.Length;
            if ((valueLength == 0) || (patternLength == 0) || (patternLength > valueLength))
                yield break;
            var misses = new int[256];
            for (var i = 0; i < 256; ++i)
                misses[i] = patternLength;
            var lastPatternByte = patternLength - 1;
            for (var i = 0; i < lastPatternByte; ++i)
                misses[pattern[i]] = lastPatternByte - i;
            var index = 0;
            while (index <= (valueLength - patternLength))
            {
                for (int i = lastPatternByte; value[index + i] == pattern[i]; --i)
                {
                    if (i == 0)
                    {
                        yield return index;
                        break;
                    }
                }
                index += misses[value[index + lastPatternByte]];
            }
        }
