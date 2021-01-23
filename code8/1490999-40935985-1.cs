    string oneBell = new string(bellCharacter, 1);
    string[] pieces = inputLine.Split(bellCharacter);
    for (int ii=0; ii<pieces.Count(); ii++)
    {
        if (string.IsNullOrEmpty(pieces[ii]))
        {
            pieces[ii] = "999";
        }
    }
    string anotherOutputLine = string.Join(oneBell, pieces);
