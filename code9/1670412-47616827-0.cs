    while (1)
    {
        folderName = Console.ReadLine();
        // if folder name is null or empty or whitespace, ask for a new folder name
        if (string.IsNullOrEmpty(folderName) || string.IsNullOrWhiteSpace(folderName))
        {
            Console.WriteLine("Ez a mező nem lehet üres. \nÚj mappa neve:");
            //(Can't be null. \nNew foldername:)
        }
        //if folder name already exists, ask for a new one
        else if (p.FolderList.Contains(folderName))
        {
            Console.WriteLine("Ez a mappanév egyszer már szerepel ebben a környezetben. Kérlek válassz újat!\nÚj mappa neve:");
            //(That name is already taken. \nNew foldername:)
        }
        else //Folder Name is valid
            break; //proceed to do stuff with the folder name
    }
    //Do my stuff with the valid folder name
