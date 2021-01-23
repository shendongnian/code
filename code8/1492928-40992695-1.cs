    Process[] roblox = Process.GetProcessesByName("RobloxPlayerBeta.exe");
    if(roblox.GetLength(0) > 0) //Check that any processes exist with that name
    {
        int id = roblox[0].Id; //set ID first as to avoid accessing the array twice
        Console.WriteLine("Id of RobloxPlayerBeta.exe is:" + id); //Write the line using the newly found id variable
    }
    else //If the process doesn't exist
    {
        Console.WriteLine("RobloxPlayerBeta.exe is not running"); //Output error of sorts
    }
