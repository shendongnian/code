    if (CheckBox1.Checked == false)
                {
                    string pass = TextBox1.Text;
                    TextBox1.TextMode = TextBoxMode.Password;
                    TextBox1.Attributes.Add("value", pass);
    
                }
    
                if (CheckBox1.Checked)
                {
                    TextBox1.TextMode = TextBoxMode.SingleLine;
                }
