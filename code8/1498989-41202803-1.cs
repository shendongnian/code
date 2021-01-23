    public string DbCommand(DbOperation command, string arguments)
    {
        string result = string.Empty;
        switch(command)
        {
            case(DbOperation.Select):
                ...
                break;
            case(DbOperation.Insert:
                ...
                break;
            default:
        }
        return result;
    }
