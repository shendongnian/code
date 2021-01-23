    x => 
    {
        x.IsValid = true;
        x.Child.IsValud = true;
        foreach(var cli in x.ChildLIst)
            cli.IsValid = true;
    }
