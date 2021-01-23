    public static void CheckIfFilesExist()
    {
        string[] array1 = Directory.GetFiles(@Properties.Settings.Default.XRFolderSavedLocation); 
        
        foreach(string name in array1)
        {
            Console.WriteLine(name);
            if (Path.GetFileName(name).StartsWith("NCR"))
            {
                 string[] splitted = name.Split('_');
                 int number1 = int.Parse(splitted[3]);
                 int number2 = int.Parse(splitted[4].Split('.')[0]);
            }
            Console.WriteLine(number1);
            Console.WriteLine(number2);
        } 
    }
