    public static int MyCustomOrder (Status status)
    {
        switch (status)
        {
            case Status.Draft     : return 1;
            case Status.Pending   : return 2;
            case Status.Validated : return 4;
            case Status.Refused   : return 3;
            default: return -1;
        }
    }
