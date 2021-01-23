    decimal sum = 0m;
    for ( int i=0; i < dataGridView1.Rows.Count; ++i)
    {
        sum += decimal.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString(), System.Globalization.NumberStyles.Any);
    }
    total.Text = sum.ToString();
  
