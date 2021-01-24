    public string FormatText(string input)
    {
        string returnText = "";
        int charCounter = 0;
        foreach(char c in input)
        {
            result += c;
            i++;
            if(i == 7)
            {
                result += Environment.NewLine;
                charCounter=0;
            }
        }
        return returnText;
    }
