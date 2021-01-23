	double num;
	bool res = double.TryParse(txtTax.Text, out num);
	if (res)
	{
	    // String is a double.
        objDIE.TaxAmount = num;
	}
