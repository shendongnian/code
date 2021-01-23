    private static readonly char[] SkipCharacters = new[] {',', '(', ')'};
    
    //Remove all unneccessery empty spaces
    private static string FormatCode(string text)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            var character = text[i];
            //set defaults - so that we do not have to check
            //for the start and end of the string
            char previous = 'x';
            char next = 'x';
            if (i > 0)
            {
                previous = text[i - 1];
            }
            if (i < text.Length - 1)
            {
                next = text[i + 1];
            }
            if ( character == ' ' &&
                    SkipCharacters.Contains( previous ) ||
                    SkipCharacters.Contains( next ) )
            {
                continue;
            }
            builder.Append( character );
        }
        return builder.ToString();
    }
