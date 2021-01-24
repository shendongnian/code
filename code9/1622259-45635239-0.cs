    private void CreateTextBox(string id, string labelName)
    {
         Label lbl = new Label();
         lbl.cssClass = "col-sm-2 control-label";
         lbl.Text = labelName;
         pnlDynamicControls.Controls.Add(lbl);
         TextBox txt = new TextBox();
         txt.cssClass = "form-control";
         txt.ID = id;
         pnlDynamicControls.Controls.Add(txt); 
    }
