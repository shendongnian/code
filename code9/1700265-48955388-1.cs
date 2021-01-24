    public static int RtfFindLastParEnd(string source)
        {
            int intLastPar = source.LastIndexOf("par}");
            if (intLastPar > 0)
            {
                intLastPar += 4; // add offset of "par}"
            }
            return intLastPar;
        }
        public static int RtfFindStartpoint(string source, int indexOfClosingBrace)
        {
            string workingString = source;
            int nestCount = 0;
            int currIndex = indexOfClosingBrace;
            while (currIndex > 0)
            {
                if (source[currIndex] == '}')
                    nestCount++;
                else if (source[currIndex] == '{')
                    nestCount--;
                if (nestCount == 0)
                {
                    return currIndex;
                }
                currIndex--;
            }
            return -1;
        }
