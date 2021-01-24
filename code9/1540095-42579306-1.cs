    private void txtITEMNAME_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // separate your values with split according to your separator
            string[] seperatedvalues = allvalues.FirstOrDefault(x => x.Contains(txb_ItemAutocomplete.Text)).Split(',');
            if(seperatedvalues.Length == 4) // make sure that you found any values at all
            {
                txb_Code.Text = seperatedvalues[0];
                txb_Price.Text = seperatedvalues[2];
                txb_Stocks.Text = seperatedvalues[3];
            }
        }
    }
