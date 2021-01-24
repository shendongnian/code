    private void btnSettled_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow r in dgvTrx.SelectedRows)
        {
            r.Cells["SettledDate"].Value = "2017/7/23"; //use the column name instead of column index
        }
        this.BindingContext[dgvTrx.DataSource].EndCurrentEdit(); 
        //the above line is added to improve the solution
        //as per the link mentioned in the accepted answer
    }
