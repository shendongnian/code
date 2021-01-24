    HtmlTableCell tdControl = new HtmlTableCell();
    HtmlGenericControl strongControl = new HtmlGenericControl("strong");
    Button  btnEdit = new Button();            
    btnEdit.Click+=new EventHandler(btnEdit_Click);
    btnEdit.Attributes["class"] = "btn btn-primary";
    btnEdit.Text = "Edit";
    Panel4.Controls.Add(tdControl);
    tdControl.Controls.Add(strongControl);
    strongControl.Controls.Add(btnEdit);
