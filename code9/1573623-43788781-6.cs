    protected bool IsPalindrome(uint x)
    { 
        // Build your string
        var chars = x.ToString();
        
        // Iterate through half of the elements
        for (var i = 0; i < chars.Length / 2; i++)
        {
             // If they are ever not equal, then it's not a palindrome
             if (chars[i] != chars[chars.Length - 1 - i])
             {
                  return false;
             }
        }
                  
        // If you've made it through, then you have a palindrome
        return true;
    }
