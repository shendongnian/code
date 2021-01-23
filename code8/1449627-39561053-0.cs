    private void cmbdealercode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get your connection string as per your project settings
            var connectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\aspnet-Northwind.mdf;Initial Catalog=aspnet-Northwind;Integrated Security=True;User Instance=True"
            if (txtinvoiceno.Text == "")
            {
                if (txtinvoicedate.Text == "")
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand cmd1 = new SqlCommand("select * from tbl_invoice where invoice_no = @no,invoice_date=@date,dealer_code=@dealercode", con))
                        {
                            cmd1.Parameters.AddWithValue("@no", txtinvoiceno.Text);
                            cmd1.Parameters.AddWithValue("@date", txtinvoicedate.Text);
                            cmd1.Parameters.AddWithValue("@dealercode", cmbdealercode.SelectedValue);
                            using (SqlDataAdapter adpt = new SqlDataAdapter(cmd1))
                            {
                                using (DataSet ds = new DataSet())
                                {
                                    using (DataTable dt = new DataTable())
                                    {
                                        adpt.Fill(dt);
                                        if (dt.Rows.Count > 0)
                                        {
                                            MessageBox.Show("Already invoice has done for the concern details");
                                            lblpaymentstatus.Text = "";
                                            lbluntilpaid.Text = "";
                                            lblpaymentstatus.Text = dt.Rows[0]["invoice_payment_status"].ToString();
                                            lbluntilpaid.Text = dt.Rows[0]["so_far_paid"].ToString();
                                        }
                                        else
                                        {
                                            DialogResult dialogueresult = MessageBox.Show("The entered details are seems to be new; your new invoice will be raised", "The Question", MessageBoxButtons.OK);
                                            lblpaymentstatus.Text = "Not Paid";
                                            lbluntilpaid.Text = "0";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
