    private void testlist()
    {
        string[,] Datavalue = new string[dataGridView1.Rows.Count, 3];
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            Datavalue[row.Index, 0] = 
                dataGridView1.Rows[row.Index].Cells[1].Value.ToString();
            Datavalue[row.Index, 1] = 
                dataGridView1.Rows[row.Index].Cells[2].Value.ToString();
            Datavalue[row.Index, 2] = 
                dataGridView1.Rows[row.Index].Cells[14].Value.ToString();
        }
        int i = 1;
        string strval = "";
        foreach (string ss in Datavalue)
        {
            strval += ss + " ";
            if (i == 15)
            {
                listBox1.Items.Add(strval);
                strval = "";
                i = 0;
            }
            i++;
        }
    }
