    if (Item_Name.Text == dr["Item_Name"].ToString() && Item_Code.Text == dr["Item_Code"].ToString())
    {
        int price = Convert.ToInt32(dr["Selling_Price"].ToString());
        if (qty.Text == "")
        {
            Selling_Price.Text = "";
        }
        else
        {
            long quantity = Convert.ToInt64(qty.Text);
            long total = price * quantity;
            Selling_Price.Text = total.ToString();
        }
    }
