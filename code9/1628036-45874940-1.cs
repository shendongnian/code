      private void button3_Click(object sender, EventArgs e)
                {
                    string file = "";
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                        {
                           if(dataGridView1.Rows[i].Cells[j].Value!=null)
                             {
                          file+=dataGridView1.Rows[i].Cells[j].Value.ToString();
                             }
                           else
                             {
                               file+="";
                             }
                        }
                    }
                    Console.WriteLine(file);
                }
