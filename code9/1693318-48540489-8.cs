    protected void grdlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string textBox1Text = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_BCICU")).Text;
    
        string textBox2Text = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_BCSupDlx")).Text;
        //remove the calculationA function and just use the code below in 
        //RowUpdating event
        txt_TotalChargeA.Text = (Convert.ToDecimal(textBox2Text.Trim()) + Convert.ToDecimal(textBox1Text.Trim())).ToString();
    }
