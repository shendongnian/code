    public static class HelperMethods
    {
        public static void GetProductBillingType(ListBox listBox)
        {
            try
            {
                DataTable dt = new DataTable();
                listBox.ClearSelection();
                DAL_Product_Registration objDAL = new DAL_Product_Registration();
                dt = objDAL.Get_ProductBillingType();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        listBox.Items.Add(new ListItem(row["billing_sub_type"].ToString(), row["billing_dtls_id"].ToString()));
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
