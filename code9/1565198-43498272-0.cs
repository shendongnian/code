    private void SubmitButton_Click(object sender, EventArgs e)
    {
        double res = 0;
    
        string a = TextBoxA.Text;
        double b = GetTextBoxValueAsDouble(TextBoxB.Text);
        double c = GetTextBoxValueAsDouble(TextBoxC.Text);
        double d = GetTextBoxValueAsDouble(TextBoxD.Text);
        double e = GetTextBoxValueAsDouble(TextBoxE.Text);
        // Use .equals to compare strings!
        if (a.Equals("c"))
        {
            // Are you sure this shouldn't be (b-c)/(d-e)?
            res= b-c/d-e;
        }
        else if (a.Equals("p"))
        {
            // Are you sure this shouldn't be (b+c)/(d+e)?
            res= b+c/d+e;
        }
        TextboxResult.Text = res.ToString();
    }
    
    private double GetTextBoxValueAsDouble(string value)
    {  
        // Ideally you should check whether the parsing has succeeded!  
        double.TryParse(value, out double doubleValue);
        return doubleValue;
    }
