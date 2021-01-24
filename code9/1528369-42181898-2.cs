    private void XmlLoad(object sender, EventArgs e)
            {
                DataSet ds = new DataSet();
                ds.ReadXml("D:\\test.xml");
    
                foreach (DataRow item in ds.Tables["Data"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.BeginEdit(true);    
                    dataGridView1.Rows[n].Cells[0].Value = item[0];
                    dataGridView1.EndEdit();
                    dataGridView1.BeginEdit(true);    
                    dataGridView1.Rows[n].Cells[1].Value = item[1];
                    dataGridView1.EndEdit();
                    dataGridView1.BeginEdit(true);    
                    dataGridView1.Rows[n].Cells[2].Value = item[2];
                    dataGridView1.EndEdit();
                }
             }
