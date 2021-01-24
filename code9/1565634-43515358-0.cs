    int CalculateScore(string word)
    {
        Dictionary<char, int> letters = new Dictionary<char, int>(){
                {'A', 1.5}, {'C', 3.9}, {'R', 3.1}, 
            }; 
        double sum = 0;
        for(int i = 0; i < word.Length; i++)
        {
            if(word[i].IsLower) word[i] = word[i].ToUpper(); 
            sum += letters[word[i]];
        }
    }
