    double a,b,c,d,total = 0;
    
    foreach(DataGridViewRow row in dataGridView1.Rows)
    {
            a = Convert.ToDouble(row.Cells[3].Value);
            b = Convert.ToDouble(row.Cells[4].Value);
            c = Convert.ToDouble(row.Cells[5].Value);
            d = Convert.ToDouble(row.Cells[6].Value);
            total = a + b + c + d;
            MessageBox.Show(total.ToString());
    }
