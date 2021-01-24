    if (selectedButton == DialogResult.OK)
    {
        // In the net line you're declaring a new, local
        // variable instead of using the class level variable
        decimal SalesTaxPct = Convert.ToDecimal(salesTaxForm.Tag);
        lblTax.Text = "Tax(" + SalesTaxPct + "%)";
    }
