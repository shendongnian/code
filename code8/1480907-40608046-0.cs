    string codeID = "347439>Dome";
    char splitChar = '>';
    if (codeID.Contains(splitChar))
    {
     int charIndex = codeID.IndexOf(splitChar);
     string subString = codeID.Substring(0,charIndex);
    }
