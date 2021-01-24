     //Function to print maximum occurances of word from dictionary with sentence
        public static void FindSentenceWithMaxOcc(List<string> list, Dictionary<string, int>dict){
            int maxSentenceIndex = 0, index = 0;
            int maxCount = int.MinValue;
            string word = "";
            Dictionary<string, int> result = new Dictionary<string, int>();
            //Iterate through dictionary containing words with total occurances
            foreach(KeyValuePair<string, int> kv in dict){
                
                //Iterating through sentences present in list
                foreach(string element in list){
                    //Split all words using space
                    string[] words = element.Split(' ');
                    //Count all occurrances of dictionary key in sentence
                    int temp = Array.FindAll(words, s => s.Equals(kv.Key.Trim())).Length;
                    
                    //Get max occurrances 
                    if(temp > maxCount){
                        maxCount = temp;
                        maxSentenceIndex = index;
                        word = kv.Key;
                    }
                    index++;
                }
                index = 0;
            }
            //Print result
            Console.WriteLine("Maximum count: " +maxSentenceIndex);
            Console.WriteLine("Word: " +word);
            Console.WriteLine("Sentence" +list[maxSentenceIndex]);
        }
