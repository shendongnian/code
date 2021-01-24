    private void button2_Click(object sender, EventArgs e)
    {       
        OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\bbbde\Database2.mdb");
        cnn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\bbbde\Database2.mdb";
        OleDbDataAdapter da = new OleDbDataAdapter("select count(*) FROM nameList where  name='" + textBox1.Text + "'and password ='" + textBox2.Text + "'", cnn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows[0][0].ToString() == "1")
        {
    
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
        }
