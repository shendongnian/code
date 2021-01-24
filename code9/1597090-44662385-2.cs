    private static void Func()
    {
        string Original = "AX_1234X_12345_X_CXY";
        string Fixed = Original.Substring(0, Original.IndexOf("_", 0));
        bool found = false;
    
        for (int i = Original.IndexOf("_", 0); i < Original.Length; i++)
        {
            if (Original[i].ToString()=="X" && found == false)
            {
                found = true;
            }
            else
            {
                Fixed += Original[i];
            }
        }
    
        Console.WriteLine(Fixed);
        Console.ReadLine();
    }
