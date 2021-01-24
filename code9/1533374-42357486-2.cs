    private void btnTotal_Click(object sender, EventArgs e)
    {
            double totalPrice = 0;
            if(unleadedRadioButton.Checked)
            {
                 totalPrice = lblDailyPrice * lblTotalLitresEntered * unleadedValue;
            }
            else if (dieselRadioButton.Checked)
            {
                 totalPrice = lblDailyPrice * lblTotalLitresEntered * dieselValue;
            }
            else if (premiumRadioButton.Checked)
            {
                 totalPrice = lblDailyPrice * lblTotalLitresEntered * premiumValue;
            }
    }
