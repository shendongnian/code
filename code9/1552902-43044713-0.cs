    using (StreamWriter sw = new StreamWriter(@"C:\test.csv"))
    {
        //Add Column Headers
        for (int col_name = 0; col_name < 1000; col_name++)
        {
            sw.Write($"{col_name},");
        }
        sw.Write("\r\n");
        //Add Rows
        for (int row = 0; row < 10000; row++)
        {
            for (int col = 0; col < 1000; col++)
            {
                sw.Write($"[{row}-{col}],");
            }
            sw.Write("\r\n");
         }  
    }
