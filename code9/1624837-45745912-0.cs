    Process[] P = Process.GetProcessesByName("pName");
    if (P.Length > 0)
    {
        Process process = P[0];  //Get the first one
    }
    else
    {
        Log("No such process!");
    }
