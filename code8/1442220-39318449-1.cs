    string[] groups = mydata.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
    int i = 0;
    while(i < groups.Length)
    {
        SendToFuncA(groups[i].Substring(0,3));
        SendToFuncB(groups[i].Substring(3,2));
        SendToFuncC(groups[i].Substring(5,2));
        i++;
    }
