    if (shiftUnicode >= 123)
    {
        int overflowUnicode = 97 + (shiftUnicode - 123);
        char character = (char)overflowUnicode;
        // value gets overwritten here
        string newText = character.ToString();
    }
    else
    {
        char character = (char)shiftUnicode;
    
        // value gets overwritten here
        string newText = character.ToString();
    }
