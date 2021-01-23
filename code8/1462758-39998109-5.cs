    public static string ErrorMessage(string value1, string value2)
    {
        int a;
        int b;
        // If we have an error parsing (note the '!')
        if(!Int32.TryParse(value1, out a) || !Int32.TryParse(value2, b))
        {
            return "Error parsing value! Wrong values!";
        }
        // If everything is ok
        return null;
    }
