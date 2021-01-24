    private double CalculateScore(Dictionary<char, double> letters, string word)
    {
        double sum = 0.0;
    
        foreach (char part in word)
        {
            if(letters.ContainsKey(char.ToUpper(part)))
            {
                sum += letters[part];
            }
        }
    
        return sum;
    }
