    dataGridView.Columns.Add("DISTANCE", "DISTANCE");  //add new column             
    int temp, col1, col2, col3, col4, col5;
    col1 = Convert.ToInt16(txtCustAge.Text);
    col2 = Convert.ToInt16(txtCustGender.Text);
    col3 = Convert.ToInt16(txtIssueDate.Text);
    col4 = Convert.ToInt16(txtCustAnnSalary.Text);
    col5 = Convert.ToInt16(txtCustCrlimit.Text);
    for (int rows = 0; rows < dataGridView.Rows.Count; rows++)
    {
        sum = col1 - Convert.ToInt16(dataGridView.Rows[rows].Cells[0].Value.ToString());
        sum += col2 - Convert.ToInt16(dataGridView.Rows[rows].Cells[1].Value.ToString());
        sum += col3 - Convert.ToInt16(dataGridView.Rows[rows].Cells[2].Value.ToString());
        sum += col4 - Convert.ToInt16(dataGridView.Rows[rows].Cells[3].Value.ToString());
        sum += col5 - Convert.ToInt16(dataGridView.Rows[rows].Cells[4].Value.ToString());
        this.dataGridView.Rows[rows].Cells[6].Value = sum;   // insert total amount into new column                 
        sum = 0;
    }
