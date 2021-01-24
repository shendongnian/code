    private void btnClearcart_Click(object sender, EventArgs e)
    {
        dgvPOScart.Rows.Clear();
        dgvPOScart.Refresh();
        if (dgvPOSproduct.Rows.Count > 0)
        {
            dgvPOSproduct.DataSource = null;
        }
            //DataTable dt = new DataTable("Products");  //this was your issue
            dt = new DataTable("Products");            //this will work
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("Select ProductID, BrandName, GenericName, Quantity, SellingPrice, Dosage, Form, S,P, VE ,  Barcode , Category , Description from Products where Status = 'Active' and Quantity > 0", cnn))
                {
                    da.Fill(dt);
                    dgvPOSproduct.DataSource = dt;
                    productwidth();
                }
            }
    }
