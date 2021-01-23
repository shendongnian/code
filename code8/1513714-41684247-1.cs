    private void button5_Click(object sender, EventArgs e)
    {
        foreach(GridView row in csv_datagridview.Rows)
        {
            decimal sumfp = Convert.Todecimal(row.Cells[7].Value);
            decimal sumfl = Convert.ToDecimal(row.Cells[6].Value);
            decimal sumcl = Convert.ToDecimal(row.Cells[5].Value);
            decimal average= (sumfp + sumfl + sumcl)/3;
            row.Cells[8].text = average;
        }
    }        
