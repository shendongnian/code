    private void AddTextbox(string id, bool isNumber)
    {
        TextBox textBox = new TextBox();
        textBox.ID = id; //set ID
        if (isNumber){ textBox.Attributes.Add("type", "number"); }; //if only numbers can be added, html attribute 'type = "number"' is added
        if (Page.IsPostBack)
        {
            // set value from passed form data
            textbox.Text = Request.Form[id];
        }
        form1.Controls.Add(textBox);
        form1.Controls.Add(new LiteralControl("<br />")); //just add <br /> html element            
    }
