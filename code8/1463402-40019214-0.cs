    private void textBox2_TextChanged(object sender, EventArgs e) {
      double p;
      if (double.TryParse(textBox2.Text, out p)) {
        // textBox2.Text has been changed and it contains double value - p
        percentage = p;
        percentage1 = percentage / 100;
        percentagecalc = percentage * total_loss;
        rate = percentagecalc / 0.5;
        rateString = System.Convert.ToString(rate);
        textBox4.Text = rateString;
        volume = rate * 0.5;
        volumeString = System.Convert.ToString(volume);
        textBox5.Text = volumeString;
      } 
      else {
        // textBox2.Text has been changed, but it can't be treated as double 
        // (it's empty or has some weird value like "bla-bla-bla")  
        textBox4.Text = string.Empty;
        textBox5.Text = string.Empty;
      }
    } 
