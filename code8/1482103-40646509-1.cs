    private String AppendPrependText(String Word)
    {
      int count = 0;
      if (int.TryParse(textBox2.Text, out count))
      {
        String padString = "".PadLeft(count, ' ');
        return padString + Word.ToString() + padString;
      }
      else
      {
        return Word;
      }
    }
    private void button1_Click_1(object sender, EventArgs e)
    {
      String Word = textBox1.Text;
      textBox3.Text = ">" + AppendPrependText(Word) + "<";
    }
