    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime localDate = DateTime.Now;
            MydbConnection db = new MydbConnection();
            MySqlConnection con = db.connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into orders (created) values(@localDate)";
            cmd.Parameters.AddWithValue("@localDate", localDate);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            long lastId = cmd.LastInsertedId;//Last inserted id
    
            cmd.CommandText = "insert into order_details (order_id,product_id,qty) values(@order_id,@product_id,@qty)";
            MySqlCommandParameter orderIdParam, productIdParam, qtyParam;
            for (int i = 0; i < listView3.Items.Count; i++)
            {
                if (i == 0)
                {
    				orderIdParam = cmd.Parameters.AddWithValue("@order_id", lastId);
    				productIdParam = cmd.Parameters.AddWithValue("@product_id", 1);
    				qtyParam = cmd.Parameters.AddWithValue("@qty", listView3.Items[i].SubItems[1]);
                }
                else
                {
    				orderIdParam.Value = lastId;
    				productIdParam.Value = 1;
    				qtyParam.Value = listView3.Items[i].SubItems[1];
                }
                
                cmd.ExecuteNonQuery();
            } 
        }
        catch (Exception es) {
            MessageBox.Show("Order not saved! "+es.Message);
        }
    }
