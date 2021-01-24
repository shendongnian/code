    private void btnLoad_Click(object sender, EventArgs e)
    {
        //validation
        if (DateTime.Compare(dtp1.Value.Date, dtp2.Value.Date) > 0)
        {
            MessageBox.Show("The start date cannot be greater than the end 
            date.");
            dtp1.Focus();
            return;
        }
    
        DataTable dt = (DataTable)dgv.DataSource;
        DataView dv = new DataView();
        dv = dt.DefaultView;
        dv.RowFilter = "dob >= '" + dtp1.Value.Date + "' and  dob <= '" +   
        dtp2.Value.Date + "'";
    }
