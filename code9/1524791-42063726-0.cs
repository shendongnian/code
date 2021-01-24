    private void button1_Click(object sender, EventArgs e)
    {
                if (!clicked)
                {
                    button1.MouseEnter-= new EventHandler(button1_MouseEnter);
                    button1.MouseLeave-= new EventHandler(button1_MouseLeave);
                    clicked = true;
                    return;
                }
    
                button1.MouseEnter += new EventHandler(button1_MouseEnter);
                button1.MouseLeave += new EventHandler(button1_MouseLeave);
                clicked = false;
      }
          
      void button1_MouseLeave(object sender, EventArgs e)
      {
                  this.button1.BackColor = Color.Red;
      }
    
      void button1_MouseEnter(object sender, EventArgs e)
      {
                  this.button1.BackColor = Color.Yellow;
      }
