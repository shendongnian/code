    private void buttonMul_Click(object sender, EventArgs e)
    {
        bool operand1Parsed = double.TryParse(textOperand1.Text, out Operand1);
        bool operand2Parsed = double.TryParse(textOperand2.Text, out Operand2);
        //If we could not parse one of them.
        if(!operand1Parsed || !operand2Parsed)
        {
            MessageBox.Show("Your message");
            return;
        }
        result = Operand1 * Operand2;
        textresult.Text = result.ToString();
    }
