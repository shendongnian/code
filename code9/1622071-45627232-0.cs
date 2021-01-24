    static int AlienMonthsAtCurrentAddress = 0;
    try
    {
    
        DateTime myDateTime;
        myDateTime = DateTime.Parse(LivedHere.Text);
    
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
