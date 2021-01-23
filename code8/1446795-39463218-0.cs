    int checkedBoxes;
    
    private void checkBox1_Click(object sender, EventArgs e)
    {
        checkedBoxes = 0;
        CheckBox check = (CheckBox)sender;
        bool result = check.Checked;
    
        if (result == true)
        {
            btnDone.Enabled = true;
        }
    
        foreach (Control c in grpToppings.Controls)
        {
            CheckBox cb = c as CheckBox;
            if (cb != null && cb.Checked)
            {
                checkedBoxes += 1;
                int how_many = checkedBoxes;
            }
        }
    }
