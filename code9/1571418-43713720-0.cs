    double number1 = 0.00;
    double answer = 0.00;
    double number2 = 0.00;
    if (double.TryParse(Number1TextBox.Text, out number1)
        && double.TryParse(Number2TextBox.Text, out number2))
    {
        answer = number1 + number2;
        AnswerLabel.Text = "The answer is: " + answer.ToString();                             
    }
    else
    {
        InvalidLabel.Text = "Please enter a Numeric Digit";
    }
