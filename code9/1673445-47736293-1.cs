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
    //uh oh whered my zero go
    int realID = int.Parse(yourInitialID);
    //The computer parsed 01234 as 1234
    //Your process of identifying for bool
    bool myNeededVar = false;
    Console.WriteLine(realID);
    Console.ReadKey();
