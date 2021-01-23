    private void btnAdd_Click(object sender, EventArgs e)
    {
        int index = 0;
        if (index < 10) // MAX_ITEMS or 10 
        {
            int dnum;
            if (int.TryParse(txtInitialise.Text, out dnum))
            {
                nums.Add(dnum);
                lstHoldValue.Items.Add("\t" + dnum);
                index++;
                txtInitialise.Text = "";
            }
        }
    }
