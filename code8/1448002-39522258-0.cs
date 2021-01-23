      FastColoredTextBox tb = new FastColoredTextBox();
      this.Controls.Add(tb);
      tb.Location = new Point(0, 0);
      tb.Visible = true;
      tb.Text = "This is some text to display in the FCTB.";
      // define a new Style... specifically a TextStyle
      Style greenstyle = new TextStyle(Brushes.Green, Brushes.White, FontStyle.Bold);
      // select the range of characters to modify
      Range rng = new Range(tb, 8, 0, 12, 0);
      // change the display to green
      rng.SetStyle(greenstyle);
