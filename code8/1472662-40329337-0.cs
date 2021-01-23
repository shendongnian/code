        int weight;
        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(txtWeight.Text, out weight))
            {
                if (weight > 0)
                    return;                
            }
            txtWeight.Clear();
            e.Cancel = true;
        }
        decimal wholesalePrice;
        private void txtwholesalePrice_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtwholesalePrice.Text, out wholesalePrice))
            {
                if (wholesalePrice > 0)
                    return;
            }
            txtwholesalePrice.Clear();
            e.Cancel = true;
        }
