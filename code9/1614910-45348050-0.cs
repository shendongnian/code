    private void EmailGen_Load(object sender, EventArgs e)
    {
    	connect.Open();
    	string emailto = "select emailaddress from emails where password = ''";
    	string emailfr = "select emailaddress from emails where password != null";
    	SqlCommand emailt = new SqlCommand(emailto, connect);
    	SqlCommand emailf = new SqlCommand(emailfr, connect);
    
    	txBEmailRec.Text = emailt.ExecuteScalar().ToString();
    	txBEmailFr.Text = emailf.ExecuteScalar().ToString();
    	connect.Close();
    
    	// TODO: This line of code loads data into the 'kwemDataSet.tblProducts' table. You can move, or remove it, as needed.
    	this.tblProductsTableAdapter.Fill(this.kwemDataSet.tblProducts);
    }
