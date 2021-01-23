    private void generatebutton_Click(object sender, EventArgs e
    {
            //Declaring Variables for Generate button
            Random rand = new Random();
            var intNum1 = rand.Next(100, 500);
            var intNum2 = rand.Next(100, 500);
            //Generate integer number 1 in first label 
            firstnumberlabel.Text = intNum1.ToString();
            //Generate integer number 2 in second label
            secondNumberlabel.Text = intNum2.ToString();
     }
    private void checkButton_Click(object sender, EventArgs e)
    {
        int userInput = 0;
        int answer = int.Parse(firstnumberlabel.Text) + int.Parse(secondnumberlabel.Text);
        if (int.TryParse(txtanswer.Text, out userInput))
        {
                if (userInput == answer)
                {
                    // Display success message
                    MessageBox.Show("Correct!");
                }
                else 
                {
                    // Display wrong answer message
                    MessageBox.Show("Incorrect!");
                }
        }
        else
        {
           MessageBox.Show("Please enter a valid answer!");
        } 
    }
    private void exitButton_Click(object sender, EventArgs e)
    {
        //Closes Application
        this.Close();
    }
    private void button4_Click(object sender, EventArgs e)
    {
        //Clears text box
        txtanswer.Text = "";
    }
