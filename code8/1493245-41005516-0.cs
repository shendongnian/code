    //Get the input
    static int GetIDInput()
    {
        int id;
        do
        {
            Console.WriteLine("Please enter your desired ID number");
            id = Convert.ToInt32(Console.ReadLine());
        }
        while (isIDAlreadyUsed(id));
        return id;
    }
    
    // Check if ID is already used
    public static bool isIDAlreadyUsed(int IDToCheck)
    {
        using (StreamReader sr = new StreamReader("Stockfile.txt"))
        {
            while (!sr.EndOfStream)
            {
                string lineValues = sr.ReadLine();
                if(lineValues.Contains(IDToCheck.ToString())
                    return true;
            }
        }
        return false;
    }
    
    static void AddStock()
    {
        // Your init
        // ...
        int id = GetIDInput(); // Get the ID
    
        //... Your logic to apply
