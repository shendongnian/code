    Dictionary<string, string> textBoxVals = new Dictionary<string, string>();
    Control form = this.FindControl("form1") as Control;
    TextBox tb;
        
    foreach (Control c in form.Controls)
    {
        if (c.GetType() == typeof(TextBox))
        {
            tb = c as TextBox;
            textBoxVals.Add(tb.ID, tb.Text);
        }
    }
