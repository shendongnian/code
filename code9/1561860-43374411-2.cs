            string sentence = "Marshall! Hello.";
            List<string> words = sentence.Split(' ').ToList();
            List<string> reversedWords = new List<string>();
    
            foreach (string word in words)
            {
                char[] arr = new char[word.Length];
    
                for( int i=0; i<word.Length; i++)
                {
                    if(!Char.IsLetterOrDigit((word[i])))
                    {
                        for ( int x=0; x< i; x++)
                        {
                            arr[x] = arr[x + 1];
                        }
                        arr[i] = word[i];
                    }
                    else
                    {
                        arr[word.Length - 1 - i] = word[i];
                    }
                }
    
                reversedWords.Add(new string(arr));
            }
    
            string reversedSentence = string.Join(" ", reversedWords);
    
            Console.WriteLine(reversedSentence);
    
