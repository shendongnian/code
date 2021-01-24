    private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Product_details  VALUES(NULL,'"+txt_box_P_Name.Text+"','"+txt_box_qty.Text+"','"+txt_box_RRate.Text+"','"+txt_box_WRate.Text+"','"+ com_box_Cat.Text + "','"+txt_depart.Text+"','"+txt_box_pur_price.Text+"','"+txt_box_GST.Text+"','"+txt_box_hsn.Text+"','"+txt_box_std_package.Text+"','"+txt_box_mas_pack.Text+"','"+txt_box_max_stock.Text+"','"+txt_box_min_stock.Text+"','"+comboBox1.Text+"');";
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                ClearTextBoxes();
                MessageBox.Show("Product Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            
        }
