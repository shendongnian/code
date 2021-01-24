    private string FormatString(string myString,string format)
    {
        const char number = '#';
        const char character = '%';
        string formatted="";
        if (format.Length < myString.Length) throw new Exception("Invalid format string");
        int i = 0;
        foreach (char c in format)
        {
            switch (c)
            {
                case number:
                    if (char.IsDigit(myString[i]))
                    {
                        formatted += myString[i];
                        i++;
                    }
                    else
                    {
                        throw new Exception("Format string doesn't match input string");
                    }
                    break;
                case character:
                    if (!char.IsDigit(myString[i]))
                    {
                        formatted += myString[i];
                        i++;
                    }
                    else
                    {
                        throw new Exception("Format string doesn't match input string");
                    }
                    break;
                default:
                    formatted += c;
                    break;
            }
                
        }
        return formatted;
    }
