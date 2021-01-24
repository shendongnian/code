     private void button2_Click(object sender, EventArgs e)
     {
            List<int> lineNo = new List<int>();
            string[] show = richTextBox1.Text.Replace("\n", " ").Split(' ');
            string type = textBox1.Text;
            int n = 0;
            for (int i = 0; i < show.Length; i++)
            {
                if (show[i] == textBox1.Text)
                {
                    n++;
                    lineNo.Add(i);
                }
            }
            this.label1.Text = n.ToString();
            this.label2.Text = str;
     }
