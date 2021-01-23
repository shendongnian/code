    private void button1_Click(object sender, EventArgs e) {
      richTextBox1.SelectAll();
      richTextBox1.SelectionBackColor = Color.White;
      if (textBox1.Text.Length < 1)
        return;
      string pattern = @"\b" + textBox1.Text.Trim() + @"\b";
      Regex findString = new Regex(pattern, RegexOptions.IgnoreCase);
      foreach (Match m in findString.Matches(richTextBox1.Text)) {
        richTextBox1.Select(m.Index, m.Length);
        richTextBox1.SelectionBackColor = Color.Yellow;
      }
    }
