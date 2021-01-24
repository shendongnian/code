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
            BankTransaction bt = new BankTransaction()
            {
                Category = currentCat,
                Amount = Convert.ToDecimal(lines[x+2]),
                Date = dt,
                Description = lines[x+1]
            };
            result.Add(bt);
        }
        else
        {
            // We are on the category line, get the name and add 
            // 1 more line to skip to the loop
            currentCat = line;
            x++;
        }
    }
