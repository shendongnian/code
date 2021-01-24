    protected bool IsPalindrome(uint x)
    {
        // Get your string
        var s = x.ToString();
        // Reverse it
        var characters = s.ToCharArray();
        Array.Reverse(characters);
        // If the original string is equal to the reverse, it's a palindrome
        return s == new string(characters);
    }
