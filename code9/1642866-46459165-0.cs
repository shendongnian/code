    public int MyNumber
    {
        //This may be different, depending on what your Settings class has been named and where its reference has been stored - but it is the same plugin.
        return App.Settings.GetValueOrDefault("myNumber",0);
    }
