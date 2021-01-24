    private void button3_Click(object sender, EventArgs e)
            {
                String file = "";
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                    {
                        file+=dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                Console.WriteLine(file);
            }
