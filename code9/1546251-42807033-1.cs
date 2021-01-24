     // Assuming 
     // Dictionary<string, int> wordHolder = new Dictionary<string, int>();  // Something
     // string LETTERS = ""; // Something
     
     List<char> listLettersToHave = LETTERS.ToList();
     Dictionary<string, int> researchResult = new Dictionary<string, int>();
     foreach (KeyValuePair<string, int> pair in wordHolder)
     {
         List<char> listLettersYouHave = pair.Key.ToList();
         bool ok = true;
     
         // If not the same count go to next KeyValuePair
         if (listLettersToHave.Count != listLettersYouHave.Count)
             continue;
     
         foreach (char toCheck in listLettersToHave)
         {
             // Search first occurence
             if (!listLettersYouHave.Contains(toCheck))
             {
                 ok = false;
                 break;
             }
     
             // Remove first occurence
             listLettersYouHave.Remove(toCheck);
         }
     
         if (ok)
             // If all letters contained then Add to result
             researchResult.Add(pair.Key, pair.Value);
     }
     // if it's a function
     // return researchResult;
