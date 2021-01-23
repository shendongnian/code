     public static IEnumerable<string> GetConjoinedWords(string text, Dictionary<char,HashSet<string>> dictionary)
     {
         if (text.Length == 0)
             yield break;
         HashSet<string> allValidWords;
         if (dictionary.TryGetValue(text[0], out allValidWords))
         {
             for (var splitIndex = text.Length; splitIndex != minimumWordLength - 1; splitIndex--)
             {
                 var candidate = text.Substring(0, splitIndex);
                 if (allValidWords.Contains(candidate))
                 {
                     yield return candidate;
                     foreach (var word in GetConjoinedWords(text.Substring(splitIndex), dictionary))
                     {
                         yield return word;
                     }
                     yield break;
                 }
             }
         }
         yield return text;
     }
