            private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value1 = list.SelectedItem.ToString();
            richTextBox1.Text = value1;
            using (StreamReader sr = new StreamReader("scripts\\" + value1))
            {
                {
                    String line = await sr.ReadToEndAsync();
                    richTextBox1.Text = line;
                }
            }
        }
