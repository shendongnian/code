    var lines = File
      .ReadLines(filename)
      .Skip(4)                            // <- skip first 4 lines
      .Select(line => line.Spilt(' '))
      .Select(words => new {
         ReservationNumber = words[0],
         deposit = Convert.ToDouble(words[1]), 
        })
      .Where(rec => GetCustomer(rec.ReservationNumber).Customer_Res_Number ==
                    rec.ReservationNumber);  
    foreach (var item in lines)
      UpdateDeposit(item.ReservationNumber, item.deposit);
