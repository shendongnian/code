    bool IsPhoneNumber(string input, string pattern)
    {
         if (input.Length != pattern.Length) return false;
         for( int i = 0; i < input.Length; ++i ) {
             bool ith_character_ok;
             if (Char.IsDigit(pattern, i))
                 ith_character_ok = Char.IsDigit(input, i);
             else
                 ith_character_ok = (input[i] == pattern[i]);
             if (!ith_character_ok) return false;
         }
         return true;
    }
