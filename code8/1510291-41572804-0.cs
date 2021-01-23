        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                dataGridView1.Rows.Add("0", "1", "2", "3");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    listBox1.Items.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
            }
        }
