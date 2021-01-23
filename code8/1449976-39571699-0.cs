    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          if (this.IsValid()) //this checks that the page passed validation, including custom validation
          {
            if (save())
            { 
              SucessMessage();
            }
          }
          else
          {
            //any custom error message (additional to the validators themselves) should go here
          }
        }
        catch (Exception ee)
        {
            ErrorMessage(ee.Message);
        }
    }
