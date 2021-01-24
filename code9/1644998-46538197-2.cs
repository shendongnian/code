         private void textBox1_TextChanged_1(object sender, EventArgs e)
         {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[1] LIKE '%{0}%'", textBox1.Text);
             dataGridView1.DataBind();
         }
        
         private void textBox2_TextChanged(object sender, EventArgs e)
         {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[2] LIKE '%{0}%'", textBox2.Text);
             dataGridView1.DataBind();
         }
