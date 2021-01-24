    private static void Func()
    {
        string Original = "AX_1234X_12345_X_CXY";
        string Fixed = Original.Substring(0, Original.IndexOf("_", 0));
        // in case you want to remove all 'X`s' after first occurrence of `'_'` 
        // just dont use that variable
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
