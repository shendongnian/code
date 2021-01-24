	private void buttonMul_Click(object sender, KeyPressEventArgs e)
	{
		if (double.TryParse(textOperand1.Text, out Operand1) &&
			double.TryParse(textOperand2.Text, out Operand2)) 
		{
			result = Operand1 * Operand2;
			textresult.Text = result.ToString();
		}
		else
		{
			// Error here. You can use a messagebox or whatever suits you.
		}
	}
