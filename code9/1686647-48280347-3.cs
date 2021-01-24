	private void numericUpDown1_ValueChanged(object sender, EventArgs e)
	{
		if (String.IsNullOrEmpty(laTotalPrice.Text))
				laTotalPrice.Text = (Calculate(Convert.ToInt32(numericUpDown1.Value), numericUpDown1.Name)).ToString();
		else
			laTotalPrice.Text = (decimal.Parse(laTotalPrice.Text) + Calculate(Convert.ToInt32(numericUpDown1.Value), numericUpDown1.Name)).ToString();
		}
	}
