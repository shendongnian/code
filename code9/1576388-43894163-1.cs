    public static bool StartsWith(this string baseString, string stringToFind, int lettersToMatch)
    {        
        for(int i = 0; i < lettersToMatch; i++)
        {
            if(baseString[i] != stringToFind[i])
            {
                return false;
            }
        }
        return true;
    }
