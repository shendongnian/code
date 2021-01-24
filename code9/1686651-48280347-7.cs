	private void nudAntibiotic_ValueChanged(object sender, EventArgs e)
	{
		if (String.IsNullOrEmpty(laTotalPrice.Text))
			laTotalPrice.Text = (Calculate(Convert.ToInt32(nudAntibiotic.Value), nudAntibiotic.Name)).ToString();
		else
			laTotalPrice.Text = (decimal.Parse(laTotalPrice.Text.Replace(' ', '0').Replace('€','0')) + Calculate(Convert.ToInt32(nudAntibiotic.Value), nudAntibiotic.Name)).ToString("C");
			nudAntibioticOldValue = Convert.ToInt32(nudAntibiotic.Value);
		}
