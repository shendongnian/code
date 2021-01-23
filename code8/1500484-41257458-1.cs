    private void calculate()
    {
    
         txtTax.Text = (Double.Parse(txtGrossAmount.Text) * (Double.Parse(txtVatno.Text) / 100.0)).ToString("#0.00");
                    if (txtGrossAmount.Text == "")
                    {
                        txtGrossAmount.Text = "0";
                    }
    
    }
