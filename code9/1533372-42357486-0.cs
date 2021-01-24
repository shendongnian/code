    private void btnTotal_Click(object sender, EventArgs e)
    {
            double total;
            if(unleaded.IsChecked())
            {
                 total = lblDailyPrice * lblTotalLitresEntered * unleaded;
            }
            else if (diesel.IsChecked())
            {
                 total = lblDailyPrice * lblTotalLitresEntered * diesel;
            }
            else if (Premium.IsChecked())
            {
                 total = lblDailyPrice * lblTotalLitresEntered * premium;
            }
    }
