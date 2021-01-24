        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = nextControlIndex++;
            if (i < panel1.Controls.Count && i < generatedArray.Length)
            {
                panel1.Controls[i].Text = generatedArray[i].ToString();
                foreach (DataGridViewRow currentRow in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell currentCell in currentRow.Cells)
                    {
                        if (Convert.ToInt32(currentCell.Value) == generatedArray[i] && 
                            currentCell.Style.BackColor == Color.Yellow)
                        {
                            currentCell.Style.BackColor = Color.Green;
                            green++;
                            panel1.Controls[i].BackColor = Color.Green;
                        }
                    }
                }
            }
            else
            {
                timer1.Stop();
            }
        }
        
