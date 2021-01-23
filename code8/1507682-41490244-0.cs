    bool IsValidSubstring(string s)
    {
        // Check for a valid length substring.
        if(s.Length == 0 || s.Length % 2 != 0)
            return false;
        
        // Loop each character and make sure it doesn't change more than once.
        char last = s[0];
        bool hasChanged = false;
        for(var c in s)
        {
            // Check for a change in character.
            if(c != last)
            {
                // If it has already changed once, then it's invalid.
                if(hasChanged)
                    return false;
                hasChanged = true;
            }
            last = c;
        }
    
        // If we get here, the only thing left to check is that it has changed at least once.
        return hasChanged;
    }
