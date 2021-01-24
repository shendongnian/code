    private void maskedtextBox1_TextChanged(object sender, EventArgs e)
    {
       double enteredValue = 0.0; // value to use when empty text box
       if (!String.IsNullOrEmpty(this.maskedtextBox1.Text))
       {
          enteredValue = double.Parse(maskedTextBox1.Text, myFormatProvider)
       }
       ProcessEnteredValue(enteredValue);
    }
