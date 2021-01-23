    string userEntered = Console.ReadLine();
    int tempInt;
    decimal tempDec;
    
    if(int.TryParse(userEntered, out tempInt))
      MessageBox.Show("You entered an int: " + tempInt);
    else if(decimal.TryParse(userEntered, out tempDec))
     MessageBox.Show("You entered a decimal: " + tempDec);
    else MessageBox.Show("You entered a string: " + userEntered);
