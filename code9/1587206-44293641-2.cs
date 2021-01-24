    internal class Program
        {
            private static void Main(string[] args)
            {
                var sortedList = new SortedList();
                sortedList.Add("1", new SortedList());
                sortedList.Add("2", new SortedList());
                sortedList.Add("3", new SortedList());
    
                ((SortedList)sortedList["1"]).Add("11", new SortedList());
                ((SortedList)sortedList["2"]).Add("21", new SortedList());
                ((SortedList)sortedList["2"]).Add("22", new SortedList());
    
                foreach (DictionaryEntry dictionaryEntry in sortedList)
                {
                    Console.WriteLine("Key: {0}, Value: {1}",dictionaryEntry.Key,dictionaryEntry.Value);
                    foreach (DictionaryEntry innerDictionaryEntry in (SortedList)dictionaryEntry.Value)
                    {
                        Console.WriteLine("Inner >>> Key: {0}, Value: {1}", innerDictionaryEntry.Key,
                            innerDictionaryEntry.Value);
                    }
                    Console.WriteLine();
                }
    
                Console.ReadLine();
            }
    }
