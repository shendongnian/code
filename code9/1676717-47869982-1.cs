    private void button3_Click_2(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        //name of column to display data from
        var selectedColumn = comboBox1.Text.ToString();
        //iterate through dataRow and display in listBox
        foreach (DataRow row in aSH_ORDER_DBDataSet1.ASH_PROD_ORDERS.Rows)
        {
            listBox1.Items.Add(row[selectedColumn].ToString());
        }
    }
