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
                // Added so that if the char is not in the dictionary the output       will just have the original char
                else { newText += A.Substring(i, 1); }
                
            }
            return newText;
        }
