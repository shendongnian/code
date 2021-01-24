    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
    {
        handled = false;
        if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
        {
            if (commandName == "MyAddin1.Connect.MyAddin1")
            {
                _applicationObject.Solution.Open(@"D:\...\tets.sln"); // *** open solution inside current VS instance
                handled = true;
                return;
            }
        }
    }
