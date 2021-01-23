    TextBox t = new TextBox();
    t.ID = "textBox_" + i;
    UpdatePanel1.ContentTemplateContainer.Controls.Add(t);
    Literal lit = new Literal() { Mode=LiteralMode.PassThrough, Text="<br/>" };
    UpdatePanel1.ContentTemplateContainer.Controls.Add(lit);
