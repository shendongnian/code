    else
    {
        string name = Console.ReadLine();
        // Before assigning the name to any item, see if it already exists
        if (Ui.Any(user => user.Name == name))
        {
            throw new UserAlreadyLoggedInException("UserName Has already taken");
        }
        // NOW assign the name
        Ui[i].Name = name;
    }
