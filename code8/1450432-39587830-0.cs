    protected void btnupdate_Click(object sender, EventArgs e)
          {
             if(!CheckValidation())
               {
                  //Some other Code
               }
          }
        
          public bool CheckValidation()
          {
            if (string.isnullorEmpty(txtphysi.Text.Trim()) )
            {
               lblerrmsg.Visible = true;
               lblerrmsg.Text = "Please Enter Physician Name";
               return false;
            }
            else
            {
              return true;
            }
            //Some other Code
          }
