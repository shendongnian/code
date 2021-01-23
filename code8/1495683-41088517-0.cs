    if (!oraReder.IsDBNull(4))                         //NEXT_INTEREST_DATE
    {
        TBNextInterestDate.Text = Convert.ToDateTime(oraReder[4]).ToString("hh:mm:ss dd/MM/yyyy");
    }
    else
    {
        TBNextInterestDate.Text = oraReder.GetValue(4).ToString();
    }
