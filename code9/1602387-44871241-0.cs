        private void Browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] matches = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*book*"); // use "*.txt" to find all text files
                if (matches.Length > 0)
                {
                    foreach (string file in matches)
                    {
                        Console.WriteLine(file);
                    }
                }
                else
                {
                    MessageBox.Show("No matches found!");
                }
            }
        }
