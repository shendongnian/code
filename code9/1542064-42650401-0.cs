        private void txtQUANTITYPOS_TextChanged(object sender, EventArgs e)
        {
            double pricePos;
            double qtyPos;
            if (!double.TryParse(txtPricePOS.Text, out pricePos))
                return;
            if (!double.TryParse(txtQUANTITYPOS.Text, out qtyPos))
                return;
            txtTOTALPOS.Text = (pricePos * qtyPos).ToString();
        }
