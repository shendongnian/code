    private void button1_Click(object sender, EventArgs e)
    {
         var sb = new StringBuilder();
         for (int i = 10; i < 101; i += 3)
         {
            sb.Append(i);
         }
         label1.Text = sb.ToString();
    }
