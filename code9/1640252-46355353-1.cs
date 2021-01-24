    private static bool charInCommon(string word1, string word2, int index)
        {
            int indexChar = 0;
            
                indexChar = word2.IndexOf(word1[index]);
            
            if (indexChar != -1)
            {
                return true;
            }
            return false;
        }
        private static bool onlyOneCaracterInCommon(string word1, string word2, int index, bool commonfound)
        {
            if (index >= word1.Length) { return commonfound; }
            if (commonfound) //if you find another return false
            {
                if (charInCommon(word1, word2, index))
                { return false; }
            }
            else
            {
                if (charInCommon(word1, word2, index))
                { commonfound = true; }
                return onlyOneCaracterInCommon(word1, word2, index + 1, commonfound);
            }           
            return onlyOneCaracterInCommon(word1, word2, index + 1, commonfound);
        }
