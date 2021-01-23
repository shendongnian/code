      private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtnum.Text = dataGridView1.SelectedRows[0].Cells["MD_Num"].Value.ToString();
            txtid.Text = dataGridView1.SelectedRows[0].Cells["MD_Num"].Value.ToString();
            txtage.Text = dataGridView1.SelectedRows[0].Cells["MD_Age"].Value.ToString();
            txtdate.Text = dataGridView1.SelectedRows[0].Cells["MD_Date"].Value.ToString();
        }
