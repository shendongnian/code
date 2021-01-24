    private void SubmitButton_Click(object sender, EventArgs e)
    {
        double res = 0;
    
        string a = TextBoxA.Text;
        double b = GetTextBoxValueAsDouble(TextBoxB.Text);
        double c = GetTextBoxValueAsDouble(TextBoxC.Text);
        double d = GetTextBoxValueAsDouble(TextBoxD.Text);
        double e = GetTextBoxValueAsDouble(TextBoxE.Text);
    
        double res = class1.Func(a, b, c, d, e);
        
        TextboxResult.Text = res.ToString();
    }
