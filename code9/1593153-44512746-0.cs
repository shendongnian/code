    private void textBox13_TextChanged(object sender, EventArgs e)
    {
       try
       {
          if(Int.TryParse(textBox13.Text) > limit)
          {
    button1.Enabled=false;
          }
          else
          {button1.Enabled=true;
          }
       }
       catch
       {
    button1.Enabled=true;
       }
    }
