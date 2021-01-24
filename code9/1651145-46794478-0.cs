    private int TotalPrice { get; set; }
    
    private int ComputeTotalPrice(int increment)
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
        yourLabel.Content = TotalPrice.ToString();
    }
