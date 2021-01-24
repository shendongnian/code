    var names = "Rafael Nadal".Split();
    foreName = names[0];
    if(names.Length == 2)
    {
        surName = names[1];
    }
    else if (names.Length == 3)
    {
        surName = names[2];
        middleName = names[1];
    }
    else
        throw new ArgumetException("Whrong number of arguments");
