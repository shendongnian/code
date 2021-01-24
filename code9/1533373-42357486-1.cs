    private void btnTotal_Click(object sender, EventArgs e)
    {
            double totalPrice = 0;
            if(unleadedRadioButton.IsChecked())
            {
                 totalPrice = lblDailyPrice * lblTotalLitresEntered * unleadedValue;
            }
            else if (dieselRadioButton.IsChecked())
            {
                 totalPrice = lblDailyPrice * lblTotalLitresEntered * dieselValue;
            }
            else if (premiumRadioButton.IsChecked())
            {
                 totalPrice = lblDailyPrice * lblTotalLitresEntered * premiumValue;
            }
    }
