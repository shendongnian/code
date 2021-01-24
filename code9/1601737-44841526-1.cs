    HtmlGenericControl gc = new HtmlGenericControl("li");
    gc.ID = "li"+counter.toString(); //This is needed to take it later
    InputList.Controls.Add(gc);
    TextBox strName = new TextBox();
    strName.Text = "txtbox"+counter.toString();
    gc.addControls.Add(strName);
