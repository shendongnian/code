    private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicNameAddress = new Dictionary<string, string>() { { "Nims", "India" }, { "john", "Japan" }, { "kan", "UK" }, { "kar", "USA" }, { "rita", "Germany" } };
            foreach (var nameAddress in dicNameAddress)
            {
                var rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = nameAddress.Key;
                dataGridView1.Rows[rowIndex].Cells[1].Value = nameAddress.Value;
            }
        }
    
        static string searchText = string.Empty;
      
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
               
                searchText += e.KeyChar;
                timer1.Start();
    
                for (int i = 0; i < (dataGridView1.Rows.Count); i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().StartsWith(searchText, true, CultureInfo.InvariantCulture))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Cells[0].Selected = true;
                        return;
                    }
                }
            }
        }
    
        // Timer Interval 1000 (Clear the searchText text after one second for new search)
        private void timer1_Tick(object sender, EventArgs e)
        {
            searchText = string.Empty;
            timer1.Stop();     
        }
