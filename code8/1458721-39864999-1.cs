    var sb = new StringBuilder();
    while (variableOne <= variableTwo)
    {
          sb.Append(string.Concat(variableOne,","));
          variableOne      = variableOne + 1;
          
    }
    outputLabel.Text = sb.ToString().Remove(sb.ToString().Length-1));
