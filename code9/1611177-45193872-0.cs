    private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op.FileName;
            }
            List<string[]> lines = File.ReadLines(textBox1.Text)
                    .Select(r => r.TrimEnd('#'))
                    .Select(line => line.Split(','))
                    .ToList();
            foreach (String item in lines[0])
            {
                listBox1.Items.Add(item);
            }
        }
