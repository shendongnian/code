    private void btnAdd_Click(object sender, EventArgs e)
    {
        int index = 0;
        if (index < MAX_ITEMS) // MAX_ITEMS set to 10
        {                
            int dnum;
            if (int.TryParse(txtInitialise.Text, out dnum))
            {
                lstHoldValue.Items.Add("\t" + dnum);
                index++;
                txtInitialise.Text = "";
            }
        }
    }
