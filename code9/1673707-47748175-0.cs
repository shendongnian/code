           private void Mouse_Enter(object sender, MouseEventArgs e)
           {
               int max = txtbox1.Text.Length;
               for (int i = 0; i < max; i++)
               {
                   txtbox1.ScrollToVerticalOffset(i);
                   //add some delay to see the scrolling effect
               }
           }
        
          private void Mouse_Leave(object sender, MouseEventArgs e)
          {
              return;
          }
