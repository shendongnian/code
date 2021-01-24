        string userChoice = RadioButtonList1.SelectedValue.ToString();
        Random r = new Random();
        int computerChoice = r.Next(3);
    
        if (computerChoice == 1)
        {
            if  (userChoice == "rock") {
    
                resultLabel.Text = "Computer chose Rock too. Tie!";
            }
            if (userChoice == "paper")
            {
                resultLabel.Text = "Computer chose Rock. You win!";
            }
            if (userChoice == "scissors")
            {
                resultLabel.Text = "Computer chose Rock. You Lose!";
            }
        }
    
        else if (computerChoice == 2)
        {
            if(userChoice == "rock") {
                resultLabel.Text = "Computer chose Rock. You win!";
            }
            if (userChoice == "paper")
            {
                resultLabel.Text = "Computer chose Paper too. Tie!";
            }
            if (userChoice == "scissors")
            {
                resultLabel.Text = "Computer chose Scissors. You lose!";
            }
        }
    
        else if (computerChoice == 3)
        {
            if (userChoice == "rock")
            {
                resultLabel.Text = "Computer chose Rock. You Lose!";
            }
            if (userChoice == "paper")
            {
                resultLabel.Text = "Computer chose Paper. You win!";
            }
            if (userChoice == "scissors")
            {
                resultLabel.Text = "Computer chose Scissors too. Tie!";
            }
        }
