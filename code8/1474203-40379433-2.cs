    private bool vowel(string word)
    {
        char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
        char[] wordChar = word.ToLower().ToCharArray();
        
        var containsVowel = wordChar != null && wordChar.Any(x => vowels.Contains(x));
        if (!containsVowel)
        {
            MessageBox.Show("Word must contain a vowel", "Error");
        }
        return containsVowel;
    }
