    List<BankTransaction> result = new List<BankTransaction>();
    string currentCat = string.Empty;
        
    for (int x = 0; x < lines.Length; x += 3)
    {
        DateTime dt;
        string line = lines[x];
        // If we can convert the line to a date, we are to the beginning
        // of a BankTransaction for the current category
        if (DateTime.TryParse(line, out dt))
        {
            // We never enter this if on the first line 
            // according to your sample text.
            BankTransaction bt = new BankTransaction()
            {
                Date = dt,
                Description = lines[x+1],
                Amount = Convert.ToDecimal(lines[x+2]),
                Category = currentCat
            };
            result.Add(bt);
        }
        else
        {
            // We are on the category line, get the name and add 
            // 1 more line to the 3 skipped in the loop
            currentCat = line;
            x++;
        }
    }
