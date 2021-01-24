    string[] lines = File.ReadAllLines("E:\\SAMPLE_FILE\\sample.txt");
                int ctr = 0;
                foreach (var line in lines)
                {
                    string text = line.ToString();
                    if (text.ToUpper().Contains(textBox1.Text.ToUpper().Trim()) || text.ToUpper() == textBox1.Text.ToUpper().Trim())
                    {
                        //MessageBox.Show("Contains found!");
                        ctr += 1;
                    }
    
                }
                if (ctr < 1)
                {
                    MessageBox.Show("Record not found.");
                }
                else
                {
                    MessageBox.Show("Record found!");
                }
