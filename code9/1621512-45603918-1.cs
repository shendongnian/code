    IParser GetParser(string version)
    {
        switch (type)
        {
            case "2":
                return new MyParser();
            default:
                throw new NewParser();
        }
    }
