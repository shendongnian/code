     private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = Enumerable.Range(0, 99999).ToArray();
            var sb = new StringBuilder();
            foreach (int a in arr)
            {
                sb.AppendLine(a.ToString("000000"));
               // textBox3.Text += a.ToString("000000")+Environment.NewLine;
    
            }
             textBox3.Text = sb.ToString();
        }
