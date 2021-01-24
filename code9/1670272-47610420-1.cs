        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter txt = new StreamWriter(@"d:\\demo.txt", append: true);
            txt.WriteLine(textBox1.Text);
            txt.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(@"d:\\demo.txt").Where(x => x.StartsWith("A"));
            textBox2.Text = string.Join(",", lines);
        }
