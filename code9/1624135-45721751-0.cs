	string strPath = "";
        var lines = System.IO.File.ReadAllLines(strPath);
    foreach (string line in lines)
    {
        if (line.Substring(1, 1) == "C")
        {
            char[] delim =  "|".ToCharArray() ;
            var C_cols = line.Split(delim);
            Output0Buffer.AddRow();
            Output0Buffer.FirstName = C_cols[0];
            Output0Buffer.LastName = int.Parse(C_cols[1]); //Note that everything is a string until cast to correct data type
            // Keep on going
        }
        if (line.Substring(1, 1) == "L")
        {
            char[] delim = "|".ToCharArray();
            var L_cols = line.Split(delim);
            Output0Buffer.AddRow();
            Output0Buffer.FirstName = L_cols[0];
            Output0Buffer.LastName = int.Parse(L_cols[1]);
            // Keep on going
        }
    }
