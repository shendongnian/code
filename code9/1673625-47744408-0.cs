    string myFirstString = "hello1,hello123,content";
    string yourSecondString = "ent";
    char delimiter = '#';
    var firstStringBuilder = new StringBuilder();
    char previousChar = delimiter;
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
    var newFirstString = firstStringBuilder.ToString();
    bool matched = newFirstString.Split(delimiter).Any(str => str == yourSecondString);
