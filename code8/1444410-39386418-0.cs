    SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=mateenwin; User ID=sa; Password=123");
    con.Open();
    SqlCommand cmd = new SqlCommand(string.Format("Select Sale_Invoice_No,Item_Code,Item_Payable_Amount from sale where Sale_Invoice_No = '{0}'", textBox1.Text), con);
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    DataSet dsInvoices = new DataSet();
    sda.Fill(dsInvoices);
    dgv.DataSource = null;
    dgv.DataSource = dsInvoices.Tables.Count > 0 ? dsInvoices.Tables[0] : null;
