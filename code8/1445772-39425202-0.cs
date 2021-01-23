        string errorMessages = String.Empty;
        
        if ((Convert.ToInt32(txtQuantity.Text)) > 20000)
        {
            errorMessages +="- Maximum quantity is 20,000!\r\n";
            txtQuantity.Focus();
            return;
        }
        if ((Convert.ToInt32(txtQuantity.Text)) <= (Convert.ToInt32(txtCriticalLevel.Text)))
        {
            errorMessages += "- Quantity is lower than Critical Level.\r\n";
            txtQuantity.Focus();
            return;
        }
        if (txtCriticalLevel.Text == "0")
        {
            errorMessages += "- Please check for zero values!\r\n";
            txtCriticalLevel.Focus();
            return;
        }
        
        if(!String.IsNullOrEmpty(errorMessages))
            MessageBox.Show(errorMessages, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
