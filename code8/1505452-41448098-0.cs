    DataTable dt = new DataTable();
    dt.Columns.Add("ColumnName", typeof(string));
    
    dt.Rows.Add("Computer432Land");
    dt.Rows.Add("Computer31 Land");
    dt.Rows.Add("Land 213 Computer");
    dt.Rows.Add("Computer asd13 Land");
    dt.Rows.Add("Computer asd13");
    dt.Rows.Add("asd13 Land");
    
    dataGridView1.DataSource = dt;
