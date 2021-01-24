            private void button1_Click(object sender, EventArgs e)
        {
            List<int> n= textBox1.Text.Split(' ').Select(int.Parse).ToList();
            var sBuilder = new StringBuilder();
            sBuilder.Append("Entered values: ");
            foreach (int num in n)
            {
                sBuilder.Append(num + " ");
                
            }
            sBuilder.AppendLine();
            richTextBox1.Text += sBuilder.ToString();
        }
