    const string str = "ABCD232ERE44RR1SGGSG3333GSDGSDG";
    var result = new List<StringBuilder> 
    {
        new StringBuilder()
    };
    char last = str[0];
    result.Last().Append(last);
    bool isLastNum = Char.IsNumber(last);
    for (int i = 1; i < str.Length; i++)
    {
        char ch = str[i];
        if (!((Char.IsDigit(ch) && isLastNum) || (Char.IsLetter(ch) && !isLastNum)))
        {
            result.Add(new StringBuilder());
        }
        result.Last().Append(ch);
        last = ch;
        isLastNum = Char.IsDigit(ch);
    }
