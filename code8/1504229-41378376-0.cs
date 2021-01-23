    int sum=0;
    for ( int i=0; i < dataGridView1.Rows.Count; ++i)
    {
        sum += (int)decimal.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString(), System.Globalization.NumberStyles.Any);
    }
    total.Text = sum.ToString();Value)
