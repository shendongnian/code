    public enum UnlPointValues
    {
        Serial = 1,  //true
        Service = 0  //false
    };
    public static string GetUnloadingPointValues(bool values)
    {
        string status = "";
        switch (values)
        {
            case (Convert.ToBoolean((int)UIHelper.UnlPointValues.Serial)):
            break;
            case (Convert.ToBoolean((int)UIHelper.UnlPointValues.Service)):
            break;
        }
    }
