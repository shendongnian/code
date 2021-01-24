        private void txtQUANTITYPOS_TextChanged(object sender, EventArgs e)
        {
            double pricePos;
            double qtyPos;
            if (!double.TryParse(txtPricePOS.Text, out pricePos))
                return;  // Will return in case txtPricePOS.Text is not a number
            if (!double.TryParse(txtQUANTITYPOS.Text, out qtyPos))
                return;  // Will return in case txtPricePOS.Text is not a number
            txtTOTALPOS.Text = (pricePos * qtyPos).ToString();
        }
