    private void button1_Click(object sender, EventArgs e)
    {
        myDatabaseDataSet.Tables[0].Rows[i][5] = textBox.Text; // You need to modify this to know which is the correct row to update.
        // Update the filtered table every time you update the main table.
        DataTableCollection tables = myDatabaseDataSet.Tables;
        DataView view1 = new DataView(tables[0]);
        BindingSource source1 = new BindingSource();
        source1.DataSource = view1;
        dataGridView1.DataSource = source1;
        source1.Filter = "Name='" + comboName.Text.Replace("'", "''") + "'";
    }
