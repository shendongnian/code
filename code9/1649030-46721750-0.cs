    class cStockIssuanceSlipDetails
    {
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public double unitcost { get; set; }
        public int quantity { get; set; }
        public double amount { get; set; }
    --Create a variable to store the value you want to pass in your sql statement
    --use this variable to store the value before concatenating in to your sql statement
        public string topass { get; set; } 
    
    }
    Filter
    
    public DataSet Products_info(int slip_no)
        {
            string queryProducts = "SELECT p.ItemCode,p.itemDescription,p.SaleCost,slip.Quantity,slip.Amount FROM tblstockissuanceslip slip " +
            "INNER JOIN tblprowareinventory pi ON slip.inventoryID_FK = pi.inventoryID " +
            "INNER JOIN tblprowareproducts p ON pi.ItemID_FK = p.ItemID "+
            "WHERE slip.SIP_NO = ""+topass+";
            using (MySqlCommand cmd = new MySqlCommand(queryProducts,con.connection))
            {
                --remove line below
                cmd.Parameters.AddWithValue("?slipno", slip_no);
                --remove line above
                DataSet ds = new DataSet();
                using (MySqlDataAdapter mda = new MySqlDataAdapter(cmd))
                {
                    mda.Fill(ds);
                    return ds;
                }
            }
        }
