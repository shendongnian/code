    TextBox tb = new TextBox();
    tb.ID = "myTextBox" + i;
    
    RequiredFieldValidator val = new RequiredFieldValidator();
    val.ControlToValidate = tb.ID;
    val.ErrorMessage = "Required field";
    
    Literal lit = new Literal();
    lit.Text = "<br>";
    
    PlaceHolder1.Controls.Add(tb);
    PlaceHolder1.Controls.Add(val);
    PlaceHolder1.Controls.Add(lit);
