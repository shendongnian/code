    private void Equal_Click(object sender, EventArgs e)
    {
        if (Double.TryParse(TB.Text, out double operand)) {
            _calculator.Calculate(operationPerf, operand);
            TB.Text = _calculator.Result.ToString();
            CO.Text = "";
        } else {
            MsgBox.Show("The TextBox does not contain a number");
        }
    }
