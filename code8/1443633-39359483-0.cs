            static void Main(string[] args)
            {    
                string text = "apple cinder apple goat apple";
                string searchWord = "apple";
    
                string[] textSplit = text.Split(' ');
    
                int searchResultCount = textSplit.Where(s => s == searchWord).Count();
    
                Console.WriteLine(text);
                Console.WriteLine(searchWord);
                Console.WriteLine(searchResultCount);
                Console.WriteLine(IndexOfOccurence(text, searchWord, 2));
    
                Console.ReadLine();
            }
    
            static int IndexOfOccurence(string s, string match, int occurence)
            {
                int i = 1;
                int index = 0;
    
                while (i <= occurence && (index = s.IndexOf(match, index)) != -1)
                {
                    if (i == occurence)
                       return index;
                    index++;
                    i++;
                }
                return -1;
            }
