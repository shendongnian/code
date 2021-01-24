        private void buttonSearch_Click(object sender, EventArgs e)
        {
			bool process = true;
            String prodName = textBoxName.Text;
            int prodID;
            double prodPrice;
			try
			{
				prodID = Convert.ToInt32(textBoxID.Text);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error in product ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
				process = false;		
			}
			try
			{
				prodPrice = Convert.ToDouble(textBoxPrice.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error in product price", MessageBoxButtons.OK, MessageBoxIcon.Error);
				process = false;
			}
			if (process)
			{
				SearchProducts(prodID);
				SearchProducts(prodName);
				SearchProducts(prodID, prodName, prodPrice);
			}
        }
