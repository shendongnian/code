    const string xml = @"<Number>
                           <Num>1</Num>
                           <Num>2</Num>
                           <Num>3</Num>
                         </Number>";
    XDocument doc = XDocument.Parse(xml);
    int i = 0;
 
    foreach (XElement num in doc.Root.Elements())
    {
        TextBox box = new TextBox
        {
            ID = "dynamicTextBox" + i,
            Text = num.Value,
            ReadOnly = true
        };
        divToAddTo.Controls.Add(box);
        divToAddTo.Controls.Add(new LiteralControl("<br/>"));
        i++;
    }
