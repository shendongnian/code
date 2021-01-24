    1> It is assumed that the Datagridview has its DataSource set to a 
     DataTable.
    2> Now, lets take dtp1 , dtp2 as the two datetimepickers
    3> I have named the first column of DataTable as dob, 2nd as age, 3rd as 
       name.
    3> The following is the code for Load button.
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
