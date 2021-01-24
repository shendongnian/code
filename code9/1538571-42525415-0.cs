    string output = string.Empty;
    const string symbol = "*";
    
    //Loop up to the half to print the upcomming way
    for (int i = 1; i <= 5; i++)
    { 
        //Based on index i we need to print asterix
        for (int up = 0; up < i; up++)
        {
          output += symbol;
        }
        
        //After all asterix are written to string we need a NewLine.
        output += Environment.NewLine;
     }
    
     //Here we start the same part as above but reverse it
     //So counting from upper end down
     for (int i = 5; i >= 1; i--)
     {
        for (int down = 0; down < i; down++)
        {
          output += symbol;
        }
    
        output += Environment.NewLine;
      }
     
      //The Trim(); will cut any free spaces before and after the string
      //So we can easily cut the last NewLine which is inserted but not needed
      MessageBox.Show(output.Trim());
