    public string FixTextUsingDictionary(string A)
        {
            Dictionary<string, string> replaceDict = ReturnReplacementDictionary();
            string newText = "";
            for (int i = 0; i < A.Length; i++)
            {
                string replacementLetter="";
                if (replaceDict.TryGetValue(A.Substring(i, 1), out replacementLetter)) 
                {
                    newText += replacementLetter;
                }
                
            }
            return newText;
        }
