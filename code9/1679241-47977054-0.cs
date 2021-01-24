    foreach (Control rtbControl in uc1.Controls)
                {
    
                    if (rtbControl is RichTextBox & rtbControl.Name == "richTextBox1")
                    {
                        rtbControl.Text = "Hello";
                    }
                }
