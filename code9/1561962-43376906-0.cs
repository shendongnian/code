    public void MainMenu() {
        // Show the main menu
    }
    public void Response(string response) {
        switch (response)
        {
            case "C1": 
                Console.WriteLine("How much would you like to deposit to your checking account?");
                string depositEntry = Console.ReadLine();
                double checkingBalance = Convert.ToInt32(depositEntry) + currentCheckingBalance;
                currentCheckingBalance += checkingBalance;
                Console.WriteLine("Your current checking balance is " + checkingBalance + "\n (X) Exit, (M) Main Menu" );
        
                string selection = Console.ReadLine().ToUpper();
                if (selection == "X")
                {
                    return;
                }
                else if (selection == "M")
                {
                    ***JUMP***
                    MainMenu();
                    return;
                }
                else
                {
                    Console.WriteLine("Your entry was invalid");
                }
        
        
                break;
        
            case "C2":      
        
                break;
        
            case "W1":
        }
    }
