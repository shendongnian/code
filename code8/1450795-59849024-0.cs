    //With Dictionary
    //This is more useful if you are looking to interview big companies otherwise use the 
     Linq option which is short and handy
    public static int MaxOccurrenceOfWord(string[] words)
        {
            var counts = new Dictionary<string, int>();
            int occurrences = 0;
            foreach (var word in words)
            {
                int count;
                counts.TryGetValue(word, out count);
                count++;
                 //Automatically replaces the entry if it exists;
                //no need to use 'Contains'
                counts[word] = count;
            }
    
            string mostCommonWord = null;
            foreach (var pair in counts)
            {
                if (pair.Value > occurrences)
                {
                    occurrences = pair.Value;
                    mostCommonWord = pair.Key;
                }
            }
            Console.WriteLine("The most common number is {0} and it appears {1} times",
                mostCommonWord, occurrences);
    
            return occurrences;
    
        }
