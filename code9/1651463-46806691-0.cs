    public string Parse(Control MainControl)
    {
       string Result = "";
       foreach (var Ctrl in MainControl.Controls)
       { 
          if (Ctrl.GetType() == TypeOf(TextBox))
          {
              Result += (TextBox)Ctrl.Text + ",";
          }
          if (Ctrl.Controls.Count > 0)
          {
              Result += Parse(Ctrl);
          }
       }
       return Result;
    }
