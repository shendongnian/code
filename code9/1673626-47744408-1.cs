    foreach (char singleChar in myFirstString)
    {
        if (Char.IsLetterOrDigit(singleChar))
        {
            firstStringBuilder.Append(singleChar);
            previousChar = singleChar;
        }
        else if(Char.IsLetterOrDigit(previousChar))
        {
            firstStringBuilder.Append(delimiter);
            previousChar = singleChar;
        }
    }
