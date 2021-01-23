    private void btnAdd_Click(object sender, EventArgs e)
    {
        int index = 0;
        string text = txtInitialise.Text;
        if (index < 10) // MAX_ITEMS or 10 
        {
            Convert.ToInt32(lstHoldValue.Items.Count);
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
