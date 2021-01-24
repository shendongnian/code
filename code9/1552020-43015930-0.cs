    DateTime dtFrom = DateTime.Now.Date.AddHours(8);  // Use Current Date and set time to 8:00 AM
    DateTime dtUpto = DateTime.Now.Date.AddHours(20);    // Use Current Date and set time to 20:00 (8:00 PM)
    DateTime dtCurr = DateTime.Now;
    if (dtFrom <= dtCurr && dtCurr <= dtUpto)
        MessageBox.Show(dtCurr.ToString("h:mm tt"));
    else
        MessageBox.Show("No");
