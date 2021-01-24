    private static string GetShortName( string name )
    {
        if ( string.IsNullOrEmpty( name ) )
        {
            return "";
        }
        string shortName = "";
        var splits = name.Split(' ');
        shortName += splits.First()[0];
        shortName += splits.Last()[0];
        return shortName;
    }
