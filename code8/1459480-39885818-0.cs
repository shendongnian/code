    foreach(Control control in this.Controls)
    {
          if(control is Button)
          {
              var btn = control as Button;
              if(btn.BackColor == Color.Green)
              {
                 btn.BackColor = Color.White;
              }
          }
    }
