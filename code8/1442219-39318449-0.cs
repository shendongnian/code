    string[] groups = mydata.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
    foreach (string item in groups)
    {
        SendToFuncA(item.Substring(0,3));
        SendToFuncB(item.Substring(3,2));
        SendToFuncC(item.Substring(5,2));
    }
