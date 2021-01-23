       private void nud1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X <= nud1.Controls[1].Width+1) {
               // Click is in text area
            }
            else {
               if (e.Y <= nud1.Controls[1].Height / 2)
                  // Click is on Up arrow
               else
                  // Click is on Down arrow
            }
        }
