    using (StreamReader file = new StreamReader(pathToFile1, true))
    {
        if ((file.ReadLine().Split(',')[0] == "Apple"))
        {
            isValid = true;
        }
        else
            isValid = false;
    }
    
    using (StreamReader file = new StreamReader(pathToFile2, true))
    {
        if ((file.ReadLine().Split(',')[0] == "Orange"))
        {
            isValid = true;
        }
        else
            isValid = false;
    }
    return myBool;
    }
