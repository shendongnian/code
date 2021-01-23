        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter("Text.txt");
            for (int i = 0; i < DataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < DataGridView1.Columns.Count; j++)
                {
                    writer.Write(DataGridView1.Rows[i].Cells[j].Value.ToString() + "\t");
                }
                writer.WriteLine("");
            }
            writer.Close();
        }
