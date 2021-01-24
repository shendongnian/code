    foreach (string line in File.ReadLines(@"path to file"))
    {
        //do validation for each line
        if (IsValidEmail(line) //etc)
        {
            // do something once line is valid.
        }
    }
