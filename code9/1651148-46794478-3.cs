    private double TotalPrice { get; set; }
    
    private void ComputeTotalPrice(double increment)
    {
        TotalPrice += increment;
    }
    
    private void chkVaccinations_CheckedChanged(object sender, EventArgs e)
    { 
        if (chkVaccinations.Checked) 
        {
            ComputeTotalPrice(priceAssociatedWithThisCheckBox);
        }
        else
        {
            ComputeTotalPrice(-priceAssociatedWithThisCheckBox);
        }
        UpdateLabel();
    }
    private void UpdateLabel()
    {
        If you want to show $ with 2 decimals
        string formattedPrice = string.Format("{0:0.00}", TotalPrice).Replace(".00","");
        lblTotalprice.Text= $"{formattedPrice}$";
    }
