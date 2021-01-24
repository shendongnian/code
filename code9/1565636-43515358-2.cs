    double CalculateScore(string word)
    {
        Dictionary<char, double> letters = new Dictionary<char, double>(){
                {'A', 1.5}, {'C', 3.9}, {'R', 3.1}, 
            }; 
        double sum = 0;
        for(int i = 0; i < word.Length; i++)
        {
            sum += letters[word[i].ToUpper()];
        }
        return sum;
    }
