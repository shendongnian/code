    int count;
    dataGridView3.Rows[0].Cells[1].Value = "1.1";
    for (int i = 1; i <= dataGridView3.RowCount - 1; i++)
    {
        count = 1;
        string abc = dataGridView3.Rows[i].Cells[2].Value.ToString() + "" + dataGridView3.Rows[i].Cells[3].Value.ToString();
    
        for (int j = 0; j < i; j++)
        {
            string def = dataGridView3.Rows[j].Cells[2].Value.ToString() + "" +  dataGridView3.Rows[j].Cells[3].Value.ToString();
            if (abc == def)
            {
                count++;
            }
        }
        dataGridView1.Rows[i].Cells["Wbs"].Value = "1." + count.ToString();
    }
