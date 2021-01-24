    private void Clickbutton_click(object sender, EventArgs e)
    {
            //// Convert.ToInt32 throws an exception if it fails 
            //// to parse the string to an integer
            //// So you don't want to parse the input directly
            ////double input = Convert.ToInt32(txtInput.Text);
            // Your second attempt is the goal
            double input;
            if (!Double.TryParse(txtInput.Text, out input))
            {
                MessageBox.Show("Please enter a valid number.");
                return; //// We are done. Nothing more to do here
            }
            txtInput.Text = input.ToString();
            
            if ( input == guess)
            {
                lblMessage.Text = "You Are Corrrect, You Win" + " "+
                    " \r\n Random Number was =  " + Convert.ToString(guess);
            }
            else if (input > guess)
            {
                lblMessage.Text = "Number is too High, Try Again";
                txtInput.Clear();
            }
            else if (input < guess)
            {
                lblMessage.Text = "Number is too Low, Try Again";
                txtInput.Clear();
            }
       }     
