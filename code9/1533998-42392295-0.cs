        string myRadioText = String.Empty;
        foreach (DataListItem item in DataList1.Items)
        {
            RadioButton rd_CS = (RadioButton)item.FindControl("rd_CS");
            RadioButton rd_CS2 = (RadioButton)item.FindControl("rd_CS2");
            RadioButton rd_CS3 = (RadioButton)item.FindControl("rd_CS3");
            RadioButton rd_CS4 = (RadioButton)item.FindControl("rd_CS4");
            
            if (rd_CS != null && rd_CS.Checked)
            {
                myRadioText = rd_CS.Text;
                Label1.Text = myRadioText.ToString();
            }
            else if (rd_CS2 != null && rd_CS2.Checked)
            {
                myRadioText = rd_CS2.Text;
                Label1.Text = myRadioText.ToString();
            }
            else if (rd_CS3 != null && rd_CS3.Checked)
            {
                myRadioText = rd_CS3.Text;
                Label1.Text = myRadioText.ToString();
            }
            else if (rd_CS4 != null && rd_CS4.Checked)
            {
                myRadioText = rd_CS4.Text;
                Label1.Text = myRadioText.ToString();
            }
            string str = Server.MapPath("~/App_Data/Quize.mdb");
            OleDbConnection ole = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + str + ";Persist Security Info=True");
            ole.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Userdata  values ('" + Label1.Text.Trim().Replace("'", "''") + "','" + Label1.Text.Trim().Replace("'", "''") + "',)", ole);
            cmd.ExecuteNonQuery();
}
