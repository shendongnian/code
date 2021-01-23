    string input = @"      """"""Step:    33    And I enter 
    
    Step:    34    And I set the  ";
      
    string pattern = @"\s{6}""{3}";
    string replacement = "\"\"\"\r\n";
    
    string output = Regex.Replace(input, pattern, replacement);
    
