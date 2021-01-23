        TableRepository repo = new TableRepository();
        // figure out the 24 hour period you need to find reserved tables for
        // it is advisible when searching by date to use a date range instead of once specific date
        // the start date and end date will satisfy the 24 hour period of tomorrow.
        // get start tomorrow
        DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(1);
        // get end of tomorrow
        DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(2);
        // call the repository method with the date range (the 24 hour period for tomorrow)
        var tablesForTomorrow = repo.GetAllReservedTables(startDate, endDate);
        // dispaly data in console
        foreach(var table in tablesForTomorrow)
        {
            Console.WriteLine("Table Number: #{0}", table.Numero);
        }
