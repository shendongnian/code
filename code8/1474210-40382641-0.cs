    void Main()
    {
        string s = "Word";
        if (hasVowels(s))
        {
            Console.WriteLine("Word has vowels");
        }
        else
        {
            Console.WriteLine("Word does not have vowels");
        }
    }
    
    private bool hasVowels(string word)
    {
        string vowels = "AEIOUaeiou";
        return word != null && word.Intersect(vowels).Any();
    }
