    private void XmlLoad(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("test.xml");
            tbOrderNr.Text = ds.Tables["OrderData"].Rows[0][0].ToString();
            tbCustommer.Text = ds.Tables["OrderData"].Rows[0][1].ToString();
            tbMaterial.Text = ds.Tables["OrderData"].Rows[0][2].ToString();
            tbForm2MatCode.Text = ds.Tables["OrderData"].Rows[0][3].ToString();
            foreach (DataRow item in ds.Tables["Data"].Rows)
            {
                dataGridView1.AllowUserToAddRows = false;
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = tem["Lenght"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Width"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Qty"].ToString();
                dataGridView1.AllowUserToAddRows = true;
            }
