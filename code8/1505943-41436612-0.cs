    string inputStr = toBeConverted.Text;
    if(inputStr.All(x=> x=='1' || x=='0')) // check all character is either 0 or 1
    {
     // it is a valid binary
     string output = Convert.ToInt32(inputStr , 2).ToString(); 
    }
    else
    {
        // Display message that not a valid binary
    }
