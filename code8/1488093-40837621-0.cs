    // If you want to compare only date part of DateTime, not time part:
    DateTime d1 = DateTime.Parse("10/11/2016");
    DateTime d2 = DateTime.Parse("01/01/2016");
    if (d1.Date > d2.Date)
    {
       // do the stuff
    }
    // For Converting it to String
    DateTime.Now.ToString("MM/dd/yyyy"); 
    DateTime.Today.ToString("MM/dd/yyyy");
    // Comparison
    int result = DateTime.Compare(today, otherdate);
    if(result < 0)
    MessageBox.Show("Today is earlier than the 'otherdate'");
    elseif(result > 0)
    MessageBox.Show("Today is later than the 'other date'");
    else
    MessageBox.Show("Dates are equal...");
    // Will give you a DateTime typed object
    var dateTime = DateTime.Parse("01/01/2016");
