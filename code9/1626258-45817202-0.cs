     DataTable dt = new DataTable("Products");
        private void dgvProductNew()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter("Select ProductID, BrandName, GenericName, Form, Dosage, Quantity, SellingPrice, D, VE from Products where Status = 'Active' and Quantity > 0", cnn))
                    {          
                        da.Fill(dt);
                        dgvPOSproduct.DataSource = dt;               
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
