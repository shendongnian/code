    public void AddressTbxLoad()
        {
            DBCon PurCon = new DBCon();
            PurCon.con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = PurCon2.con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format("SELECT address FROM tbl_Supplier WHERE supplier_name LIKE '{0}%'", cbx_vendor.Text);
            SqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string address = red.GetString(0);
                txb_address.Text = address;
                
            }
            PurCon.con.Close();
        }
        private void cbx_vendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txb_address.Clear();
            AddressTbxLoad();
        }
        private void Purchase_Load(object sender, EventArgs e)
        {
            VendorTbxLoad();
        }
