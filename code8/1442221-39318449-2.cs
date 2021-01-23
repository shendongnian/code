    string[] groups = mydata.Split(new char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
    foreach (string item in groups)
    {
        string[] InnerGroup = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        SendToFunctionA(InnerGroup[0] + "," + InnerGroup[1] + "," + InnerGroup[2]);
        SendToFunctionB(InnerGroup[3] + "," + InnerGroup[4]);
        SendToFunctionC(InnerGroup[5] + "," + InnerGroup[6]);
    }
