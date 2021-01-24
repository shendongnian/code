    //Their process should add zero to beginning
    bool isUserElevated = false;
    //The ID before auto-magic
    string yourInitialID = "1234";
    //Other person's process of adding identifier
    if (isUserElevated == true)
    {
        yourInitialID = "1" + yourInitialID;
    }
    else
    {
        yourInitialID = "0" + yourInitialID;
    }
    //Your process of identifying for bool
    bool myNeededVar = false;
    //uh oh whered my zero go
    int realID = int.Parse(yourInitialID);
    Console.WriteLine(realID);
    Console.ReadKey();
