      namespace Hi
    {
        class Program
        {
            static void Main(string[] args)
            {
            
    
        string t1 = "A book was lost. There is a book on the table. Is that the book?";
    
                Console.WriteLine(t1);
                Console.WriteLine(" - Found {0} articles, should be 2.", CountArticles(t1));
                Console.ReadKey();
            }
    
            static int CountArticles(string text)
            {
                int count = 0;
    
                // Here you may also try TextInfo
                //Make string as a Title Case
                //the beginning of the string OR followed by space would be now  'A'
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                text = textInfo.ToTitleCase(text); 
    
    
                {
                    for (int i = 0; i < text.Length; ++i)
                    {
                        if (text[i] == 'A')
                        {
                            ++count;
                        }
                    }
                    return count;
                }
            }
        }
    }
