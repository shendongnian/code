    private void btnArchives_Click(object sender, EventArgs e)
    {
                if (!clicked)
                {
                    btnArchives.MouseEnter-= new EventHandler(btnArchives_MouseEnter);
                    btnArchives.MouseLeave-= new EventHandler(btnArchives_MouseLeave);
                    clicked = true;
                    return;
                }
    
                btnArchives.MouseEnter += new EventHandler(btnArchives_MouseEnter);
                btnArchives.MouseLeave += new EventHandler(btnArchives_MouseLeave);
                clicked = false;
      }
          
      void btnArchives_MouseLeave(object sender, EventArgs e)
      {
                  this.btnArchives.BackColor = Color.FromArgb(15, 34, 53);
      }
    
      void btnArchives_MouseEnter(object sender, EventArgs e)
      {
                  this.btnArchives.BackColor = Color.FromArgb(9, 18, 28);
      }
