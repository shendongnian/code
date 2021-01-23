            List<string> sentenses = new List<string>();
            sentenses.Add("hi, my name is Sam.");
            sentenses.Add("Hi,is,settled,drums.");
            sentenses.Add("Add all your sentenses here");
            string longestSentense ="";
            int longestCount = 0;
            foreach(string sentense in sentenses)
            {
                string[] words = Regex.Split(sentense, "[^a-zA-Z]"); // cut sentense by all not letter character
                int count = 0;
                for (int i=0;i<words.Length-1;i++)
                {
                    // check if last letter of words[i] is the same letter as the first or words[i+1]
                    if(words[i].Equals("") || words[i+1].Equals("")) continue; // don't look to "empty word"
                    if (words[i][words[i].Length-1].Equals(words[i + 1][0])) count++;
                }
                // if here is the biggest number of matching words, we save it
                if(count>longestCount)
                {
                    longestCount = count;
                    longestSentense = sentense;
                }
            }
            Console.WriteLine("The sentence that contains the most of matching words : \n"
                + longestSentense + "\n"
                + " with " + longestCount + " junctions between matching words.");
            Console.ReadKey();
