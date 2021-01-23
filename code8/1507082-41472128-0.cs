    bool containsOnlyLettersAndSpaces = true;
    foreach( char c in answer )
    {
        if( !Char.IsLetter( c ) && !Char.IsWhiteSpace( c ) )
        {
            containsOnlyLettersAndSpaces = false;
            break;
        }
    }
