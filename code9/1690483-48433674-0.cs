    var actions = new Dictionary<string, Action>
    {
      { "1", atm.CreateAccount }
      { "2", AtmSelection } //This would do the same as below with the atmActions dictionary
      { "3", atm.AccountInfo }
    }
    
    var atmActions = new Dictionary<string, Action>
    {
      { "1", atm.Deposit }
      { "2", atm.Withdraw }
    }
    var input = GetInput(); //From stdin as you do currently
    if (actions.TryGetValue(input, out var action)) 
    {
        action();
    }
    else
    {
        Console.WriteLine("Invalid Selection");
    }
