    private void btnSubmit_Click(object sender, EventArgs e)
    {
    	var classType = txtBoxClass.Text;
    	var name = txtBoxName.Text;
    
        decimal grade;
        if (! decimal.TryParse(txtBoxGrade.Text, out grade))
        {
            lblAnswer.Text = "Input a number!";
            return;
        }            
    
        switch (classType)
        {
            //Case for Math class and grade comparison
            case "m":
            case "M":
                if (grade > -1 && grade <= 100)
                {
                    if (grade >= 94)
                    {
                        lblAnswer.Text = name + "'s grade in Math is an A";
                    }
                    else if (grade <= 93)
                    {
                        lblAnswer.Text = name + "'s grade in Math is an A-";
                    }
                    else if (grade <= 89)
                    {
                        lblAnswer.Text = name + "'s grade in Math is a B+";
                    }
                    else if (grade <= 86)
                    {
                        lblAnswer.Text = name + "'s grade in Math is an B";
                    }
                    else if (grade <= 83)
                    {
                        lblAnswer.Text = name + "'s grade in Math is a B-";
                    }
                    else if (grade <= 79)
                    {
                        lblAnswer.Text = name + "'s grade in Math is a C+";
                    }
                    else if (grade <= 76)
                    {
                        lblAnswer.Text = name + "'s grade in Math is a C";
                    }
                    else if (grade <= 73)
                    {
                        lblAnswer.Text = name + "'s grade in Math is a C-";
                    }
                    else if (grade <= 69)
                    {
                        lblAnswer.Text = name + "'s grade in Math is a D";
                    }
                    else if (grade < 65)
                    {
                        lblAnswer.Text = name + "'s grade in Math is an F";
                    }
    
                    //Clears the text boxes when the Submit button is clicked.
                    txtBoxName.Text = "";
                    txtBoxClass.Text = "";
                    txtBoxGrade.Text = "";
                }
                else { lblAnswer.Text = "Input a number between 0 and 100!"; }
                break;
        }
    }
