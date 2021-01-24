    private static Regex validator = new Regex(@"^[a-zA-Z0-9]*$"); // no need to create it over and over again in the constructor
    public HexString(string str)
    {
        if(!validator.IsMatch(str))
            throw new FormatException("The string was not recognized as a valid hexa-decimal value");
        _string = str;
    }
