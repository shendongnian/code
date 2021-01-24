    private void txt_Validating(object sender, CancelEventArgs e)
            { // Convert User input to TitleCase After focus is lost.
              //Cast the sender to a textbox so we do not need to use the textbox name directly
                TextBox txtBx = (TextBox)sender; 
                if (Utillity.IsAllLetters(txtBx.Text) | !string.IsNullOrEmpty(txtBx.Text))
                {
                    errorProvider.Clear();
                    txtBx.Text = Utillity.ToTitle(txtBx.Text);//using the cast TextBox
                    isValid = true;
                }
                else
                {
                    errorProvider.SetError(txtBx, "InValid Input, please  reType!!");
                    isValid = false;
    
                    //MessageBox.Show("Not Valid");
                }
            }
