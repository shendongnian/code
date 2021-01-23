    private bool vowel(string word)
    {
        char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
        if (!String.IsNullOrWhitespace(word))
        {
            char[] wordChar = word.ToLower().ToCharArray();
        }
        else
        {
            MessageBox.Show("Please enter a word", "Error");
            return false;
        }
        
        var containsVowel = wordChar.Any(x => vowels.Contains(x));
        if (!containsVowel)
        {
            MessageBox.Show("Word must contain a vowel", "Error");
        }
        return containsVowel
    }
