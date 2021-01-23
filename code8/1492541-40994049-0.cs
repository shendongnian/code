    protected void checkbox_CheckedChanged(object sender, EventArgs e)
    {
          Label l = (Label)this.Page.FindControl("myLabel");
          if (l != null && checkbox is checked)
          {
              l.Text = "second label";
          }
          else
         {
              l.Text = "first label";
         }
     }
:)
