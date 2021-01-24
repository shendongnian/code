    protected bool IsPalindrome(uint x)
    {
        var characters = x.ToString().ToCharArray();
        Array.Reverse(characters);
        return x.ToString() == string(characters);
    }
