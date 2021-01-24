    var dayString = DateTime.Now.AddDays(-5).ToString(); //Settings.Default["Day"].ToString()); // Some day From Settings
    
    if (!DateTime.TryParse(dayString, out var someDay))
    {
       throw new ApplicationException($"Invalid input date : {dayString}");
       //return; // return if not a valid date stored in settings
    }
    
    var daysLeft = ( DateTime.Now - someDay).Days; // days left as int (number)
    
    textBox3.Text = daysleft.ToString();
    
    var amountString = "234.34"; // Settings.Default["Amount"]; // Some amount From Settings
    
    if (!double.TryParse(amountString, out var amount))
    {
       throw new ApplicationException($"Invalid input Amount : {amountString}");
        //  return; // return if not a valid double stored in settings
    }
    
    var total = amount / daysLeft;
