    private string originalName;
    public void cc()
    {
        cbBname.Items.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from BkhurData";
        db.ExeNonQuery(cmd);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {
            cbBname.Items.Add(dr["Name"].ToString());
            originalName =  dr["Name"].ToString()
        }
    }
    private void BkhurUpdate_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update BkhurData set Name='" + tbBpname.Text + "',Details='" + tbBpdetails.Text + "',Price='" + tbBpprice.Text + "',Size='" + tbBpsize.Text + "', Quantity ='"+tbBpquantity.Text+"' where Name = '" + originalName+ "'";
        db.ExeNonQuery(cmd);
        tbBpname.Text = "";
        tbBpdetails.Text = "";
        tbBpprice.Text = "";
        tbBpsize.Text = "";
        tbBpquantity.Text = "";
        cc();
        MessageBox.Show("updated successfully");
    }
