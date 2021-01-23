    private IEnumerable<NotServedMenu> NotServedMenusFromStrings(IEnumerable<string> strings)
    {
        return (from x in strings select ParseNotServedMenuFromString(x)).ToArray();
    }
    private NotServedMenu ParseNotServedMenuFromString(string str)
    {
        var parts = str.Split('|');
        // Validate
        if (parts.Length != 3)
            throw new ArgumentException(string.Format("Unable to parse \"{0}\" to an object of type {1}", str, typeof(NotServedMenu).FullName));
        bool notServedVal;
        if (!bool.TryParse(parts[1], out notServedVal))
            throw new ArgumentException(string.Format("Unable to read bool value from \"{0}\" in string \"{1}\".", parts[1], str));
        // Create object
        return new NotServedMenu() { Menu = parts[0], 
                                     NotServed = notServedVal, 
                                     AlternateMenu = parts[2] }; 
    }
