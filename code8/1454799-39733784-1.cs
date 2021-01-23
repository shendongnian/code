    private void Calculate_Click(object sender, EventArgs e)
            {
    
                int num1 = Number1.Text==""?0:Convert.ToInt32(Number1.Text);
                int num2 = Number2.Text==""?0:Convert.ToInt32(Number2.Text);
                int result = 0;
                
        
                if (Addition.Checked == true)
                {
                    result = num1 + num2;
                }
               else if (Subtraction.Checked == true)
                {
                    result = num1 - num2;
                }
                else if (Multiplication.Checked == true)
                {
                    result = num1 * num2;
                }
                else
                {
                    resultBox.Text = "Error, no parameter selected";
                }
        	string resultString = Convert.ToString(result);
                resultBox.Text = resultString;
            }
