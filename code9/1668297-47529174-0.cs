    public string GetIndex(string value, string stringToCompare, char wildcard)
    {
        bool stringsMatch = true;
        for (int i = 0; i < value.Length; i++)
        {
            //wild card match - return the value in stringTocompare
            if (value[i] == wildcard)
            {
                return stringToCompare[i].ToString();
            }
            else if (value[i] != stringToCompare[i]) //strings don't match
            {
                stringsMatch = false;
            }
        }
    
        return stringsMatch ? "" : null;
    }
