    int variableOne;
    int variableTwo;
    if (int.TryParse(variableOneText.Text, out variableOne))
    {
        if (int.TryParse(variableTwoText.Text, out variableTwo))
        {
            StringBuilder sb = new StringBuilder();
        
            for (int i = variableOne; i <= variableTwo; i++)
            {
                if (sb.Length > 0)
                    sb.Append(",");
                
                sb.Append(i);
            }
            
            outputLabel.Text = sb.ToString();
        }
        else
        {
            MessageBox.Show("Please enter a number");
        }
    }
    else
    {
        MessageBox.Show("Please enter a number");
    }
