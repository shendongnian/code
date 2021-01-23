        public static bool IsWordPartOfString(string startString, string word)
        {
            var tempTable = startString.ToArray();
            foreach (var c in word)
            {
                var index = Array.FindIndex(tempTable, myChar => myChar == c);
                if (index == -1)
                {
                    return false;
                }
                tempTable[index] = ' ';
            }
            return true;
        }
