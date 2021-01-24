    private void btnCalc_Click(object sender, EventArgs e)
        { 
            //Declare Variables
            double dblSpeed;
    
            //Assign user input to double.
            dblSpeed = Convert.ToDouble(txtInput.Text);
    
    
            //Multiply dblSpeed by 5 and put into lable
            lblOutput.Text = (dblSpeed * 5).ToString() ;
            
        }
