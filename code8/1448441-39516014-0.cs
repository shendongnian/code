            private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(richTextBox1.Text.Trim()))
            {
                MessageBox.Show("Please input text...");
                return;
            }
            var textValues = richTextBox1.Text.Split('\n').Select(txt => $"'{txt}'");
            var concatValues = string.Join(",", textValues);
            richTextBox2.Text = concatValues;
            System.Console.WriteLine();
        }
