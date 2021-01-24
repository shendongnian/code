    static void FindLastName(params School[] findLName)
    {
        Write("What is the last name? ");
        string findL = ReadLine();
        // Create a variable to track if we find a match
        bool foundStudent = false;
            
        // Search through each array item
        for (int i = 0; i < findLName.Length; i++)
        {
            // See if this item's last name is a match
            if (findLName[i].LName == findL)
            {
                // If it is, set our variable to this student and break out of the for loop
                PrintStudent(findLName[i]);
                foundStudent = true;
            }
        }
        // If our variable is false (or "not true" in the syntax here), we tell the user
        if (!foundStudent)
        {
            Write("No results found with that last name {0}.", findL);
        }
    }
