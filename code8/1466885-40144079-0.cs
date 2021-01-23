	int num = 0;
	bool atLeastOneisNegative = false;
	foreach (Control x in this.Controls)
	{
		if (x is TextBox)
		{
			num = 0;
			num = int.Parse(((TextBox)x).Text);
			if(num < 0)
			{
				atLeastOneisNegative = true;
				MessageBox.Show("Please enter a positive first number");
			}
		}
	}	
	
	if(!atLeastOneisNegative)
	{
		int num1 = int.Parse(txtNum1.Text);
		int num2 = int.Parse(txtNum2.Text);
		int num3 = int.Parse(txtNum3.Text);
		int sum = num1 + num2 + num3;
		txtResult.Text = sum.ToString();
	}
	
