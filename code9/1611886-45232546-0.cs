    string tColumnString = String.Empty;
    
    tColumnString = tDataTable.Rows[x][y].ToString();
    if (tColumnString.Contains("e+013") || tColumnString.Contains("e+012") || tColumnString.Contains("e+011") || tColumnString.Contains("e+07"))
    {
        double tColumnDouble = 0;
        if (double.TryParse(tColumnString, out tColumnDouble))
        {
            Console.WriteLine("Double konvertiert: " + tColumnDouble.ToString());
            tColumnString = Convert.ToString(tColumnDouble);
        }
    }
