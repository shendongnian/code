    // Data (lines) to process
    var lines = File
      .ReadLines(filename)
      .Skip(4)                            // <- Skip first 4 lines (file's caption?)
      .Select(line => line.Split(' '))
      .Select(words => new {
         ReservationNumber = words[0],
         deposit = Convert.ToDouble(words[1]), 
        })
      .Where(rec => GetCustomer(rec.ReservationNumber).Customer_Res_Number ==
                    rec.ReservationNumber);  
    // Data Processing
    foreach (var item in lines)
      UpdateDeposit(item.ReservationNumber, item.deposit);
