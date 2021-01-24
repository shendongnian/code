     string input1 = "AX_1234X_12345_X_CXY";
     string pattern1 = "^[A-Z]{1,2}_[0-9]{1,4}(X)";
     string newInput = string.Empty;
     Match match = Regex.Match(input1, pattern1);
     if(match.Success){
        newInput =  input1.Remove(match.Groups[1].Index, 1);
     }            
     Console.WriteLine(newInput);
