    private void calculate()
    {
       if (txtGrossAmount.Text == "")
                    {
                        txtGrossAmount.Text = "0";
                    }
         txtTax.Text = (Double.Parse(txtGrossAmount.Text) * (Double.Parse(txtVatno.Text) / 100.0)).ToString("#0.00");
                    
    
    }
