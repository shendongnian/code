    System.Windows.Forms.TextBox textbox1 =  new System.Windows.Forms.TextBox(); 
                textbox1.Text = "£1,252,52";
                string pattern = @"^\£?((\d{0,3})*,?(\d{3},?)*\d{0,3}(.\d{0,3})?|\d{1,3}(.\d{2})?)$";
                if (System.Text.RegularExpressions.Regex.IsMatch(textbox1.Text, pattern))
                {
                    //if string matched
                }
                else
                {
                    //if not matched
                }
