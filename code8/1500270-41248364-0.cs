    string sERH = "Error Recovery Histogram:";            //MAKE SURE YOU PUT THE : IN THERE!
    int erhPos = fLine.IndexOf(sERH);
    string[] valsERH = new string[16];                                             //WHY 16??
    char spliter = ' ';                     //YOU ONLY NEED THE CHAR MARKER FOR YOUR SPLITTER
    string[] subStrings = sERH.Split(spliter);                       //CREATE YOUR SUBSTRINGS
    int[] iNumbers = new int[subStrings.Count()];                //CREATE YOUR ARRAY OF INT'S
    for (int i = 0; i < subStrings.Count(); i ++)
    {
        try
        {
            iNumbers[i] = Convert.ToInt32(subStrings[i]);   //IF YOU CAN CONVERT IT TO AN INT
        }
        catch { }                                                   //OR LEAVE IT AS A STRING
    }
