            private string NumEnter(int score)
            {
                string result;
                //Set parameters for user input and prompt with textbox if outside parameters.
    
                if (score < 0 | score > 100)
                {
                    MessageBox.Show("Enter a score 0-100.");
                    this.txtScore.Text = "";
    
                }
    
                //Set parameters for each letter grade
                else if (score >= 0 && score <= 100)
                {
                    if (score >= 90)
                    {
                        result = lblGrade.Text = "A";
                    }
                        
                
                    else if (score >= 80)
                    {
                        result = lblGrade.Text = "B";
                    }
                    
    
                   else if (score >= 70)
                    {
                        result = lblGrade.Text = "C";
                    }
    
                   else if (score >= 60)
                    {
                        result = lblGrade.Text = "D";
                    }
                    
                   else
                    {
                        result = lblGrade.Text = "F";
                    }
                    return result;
    
                }
    
                //Concatenate the input user score and output a message with the letter grade.
                lblGrade.Text = "You entered an " + txtScore.Text + " which is a " +
                    lblGrade.Text + " letter grade.";
                
            }
