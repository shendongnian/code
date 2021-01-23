    using System.Linq;
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
    //The `Intersect` method takes two `char` sequences and returns a sequence
    //of `char` that exists in both of them.  The `Any` method returns true if
    //there is anything in the resulting sequence.
    private bool hasVowels(string word)
    {
        string vowels = "AEIOUaeiou";
        return word != null && word.Intersect(vowels).Any();
    }
