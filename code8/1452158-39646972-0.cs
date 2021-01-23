            string body= string.Empty;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                { 
                    //get text from textbox
                    string text_content = control.Value;
                    //make sure its not empty
                    if (!string.IsNullOrEmpty(text_content))
                    {
                        body +=  /*all your mumbo jumbo HTML table data  + */ text_content;
                    }
                        
                }
            }
            mail.Body = body;
