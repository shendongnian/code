    private void btnadd_Click(object sender, EventArgs e)
    {
       if (!rbmale.Checked && !rbfemale.Checked && !rbothers.Checked)
        {
            MessageBox.Show("Please select gender ", "Error");
            return;
        }
