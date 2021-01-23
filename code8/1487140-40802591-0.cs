     static void Main(string[] args)
        {
            string[] FileLines = File.ReadAllLines("your text file path");
            Hashtable hashtable = new Hashtable();
            foreach (string line in FileLines)
            {
                if (!hashtable.ContainsKey(line))
                {
                    hashtable[line] = line;
                }
            }
            foreach (var item in hashtable.Values)
            {
                //here you can match with your text box values...
                //why you need to insert text file data into hash table really i dont know.from above foreach loop inside only you can match the values.might be you have some requirement for hash table i hope
                string textboxVal = "text1";
                if (item == textboxVal)
                {
                    //both are matched.do your logic
                }
                else{
                    //not matched.
            }
            }
        }
