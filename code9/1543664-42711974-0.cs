    DataTable dt = new DataTable();
    dt.Columns.Add("Column1",typeof(datatype));//column 0
    dt.Columns.Add("Column2",typeof(datattype));//column 1    
    if(ListBox1.Items.Count == ListBox2.Items.Count)
    {
    for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    dt.Rows.Add(ListBox1.Items[i].Text, ListBox2.Items[i].Text);
                }
                dataGridView1.DataSource = dt;
                dataGridView1.DataBind();
    }
