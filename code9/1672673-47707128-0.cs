    public class UpDownWith0 : System.Windows.Forms.NumericUpDown
    {
      private System.Windows.Forms.Timer addzeros = new System.Windows.Forms.Timer();
      public UpDownWith0()
      {
        this.addzeros.Interval = 500; //Set delay to allow multiple keystrokes before we start doing things
        this.addzeros.Stop();
        this.addzeros.Tick += new System.EventHandler(this.Sync);
      }
      protected override void OnTextBoxTextChanged(object source, System.EventArgs e)
      {
        this.addzeros.Stop(); //reset the elapsed time every time the event fires, handles multiple quick proximity changes as if they were one
        this.addzeros.Start();
      }
      public void Sync(object sender, System.EventArgs e)
      {
        int val;
        this.addzeros.Stop();
        if (this.Text.Length > 4)
        {
          //I never want to allow input over 4 digits in length. Chop off leftmost values accordingly
          this.Text = this.Text.Remove(0, this.Text.Length - 4);
        }
        int.TryParse(this.Text, out val); //could use Value = int.Parse() here if you preferred to catch the exceptions. I don't.
        if (val > this.Maximum) { val = (int)this.Maximum; }
        else if (val < this.Minimum) { val = (int)this.Minimum; }
        this.Value = val; //Now we can update the value so that up/down buttons work right if we go back to using those instead of keying in input
        this.Text = val.ToString().PadLeft(4, '0'); //IE: display will show 0014 instead of 14
        this.Select(4, 0); //put cursor at end of string, otherwise it moves to the front. Typing more values after the timer fires causes them to insert at the wrong place
      }
    }
