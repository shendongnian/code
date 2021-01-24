       protected void AddTextBox(object sender, EventArgs e)
       {
          bool found = false;
          foreach (Control item in pnlPageRefresh2.Controls.OfType<DropDownList>())
          {
              if (item.ID == "weather2")
              {
                  found = true;
                  pnlPageRefresh2.Controls.Remove(item);
                  break;
              }
          }
          //check if not found then create it
          if(!found)
          {
              create_cntrl();
          }
       }
