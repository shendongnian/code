    private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count>0){
               textBox1.Text = dataGridView1.SelectedRows[0].Cells["HomeNM"].Value.ToString();
               textBox2.Text = dataGridView1.SelectedRows[0].Cells["HostNM"].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells["odd1NM"].Value.ToString();
        }
