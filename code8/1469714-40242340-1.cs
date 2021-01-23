      var panel1Texts = this.Controls.OfType<TextBox>().ToArray();
      var panel2Texts = this.Controls.OfType<TextBox>().ToArray();
      Func<string, bool> isInvalid = (text) =>
      {
        int res;
        return !int.TryParse(text, out res);
      };
      var errorText = panel1Texts.FirstOrDefault(tb => isInvalid(tb.Text));
      if (errorText != null)
      {
        // Error handling
      }
      errorText = panel2Texts.FirstOrDefault(tb => isInvalid(tb.Text));
      if (errorText != null)
      {
        // Error handling
      }
      var sum = panel1Texts.Zip(panel2Texts, (tb1, tb2) => int.Parse(tb1.Text) * int.Parse(tb2.Text)).Sum();
    textBox3.Text = sum.ToString();
