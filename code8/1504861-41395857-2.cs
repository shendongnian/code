    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml("D:\\data.xml");
        //split selected item by spaces
        var values = listBox1.SelectedItem.ToString().Split(' ');
        var selectedRow = ds.Tables["Tabela"].AsEnumerable()
            .Where
                (r => r["Room"].ToString() == values[0] && 
                r["Name"].ToString() == values[1] && 
                r["Surname"].ToString() == values[2]).FirstOrDefault();
        if (selectedRow != null)
        {
            textBox1.Text = selectedRow["Name"].ToString();
            textBox2.Text = selectedRow["Surname"].ToString();
            textBox3.Text = selectedRow["PESEL"].ToString();
            textBox4.Text = selectedRow["Room"].ToString();
        }
    }
