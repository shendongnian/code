            // User input stored in Temp Var
            string myText = tbProductId.Text;
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (myText.Equals("") ||(regex.IsMatch(myText.ToString())))
            {
                MessageBox.Show("Please enter a Valid value no special chars or leaving this blank!!!!");
            }
            
            else 
            {
                tbProductId.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInf‌​‌​o.ToTitleCase(tbPr‌​od‌​uctId.Text.ToLow‌​er());
                tbProductId.Focus();
                tbProductId.Select(tbProductId.Text.Length, 0);
                //Move Cursor to location of where error
 }
