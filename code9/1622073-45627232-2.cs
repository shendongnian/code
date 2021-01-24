    static int AlienMonthsAtCurrentAddress = 0;
    try
    {
    
        DateTime myDateTime;
        myDateTime = DateTime.Parse(LivedHere.Text);
    
        // If you don't wish to subtract from today's date use required date in place of DateTime.Now
        TimeSpan span = DateTime.Now.Subtract ( myDateTime ); 
        if (span.Days < 60)
        {
            Address2Panel.Visible = true;//shows the Address2Panel
        }
        else
        {
            ClearAddress2Panel();//hides also the Address2Panel
        }
    
    }
    catch { }
