    private void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Close();
            conn.Open();
    
            SqlCommand command = new SqlCommand ("Update Stock_Jewelry  set Stock_Type = @Stock_Type, Stock_No = @Stock_No , Quantity = @Quantity, Item_Description = @Item_Description, Item_Type = @Item_Type, No_of_Gems = @No_of_Gems, Gem_Type = @Gem_Type, Image = @Image WHERE  ID = @ID",conn);
    
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = txt_ID.Text;
            command.Parameters.Add("@Stock_Type", SqlDbType.VarChar).Value = Stock_Type.Text;
            command.Parameters.Add("@stock_no", SqlDbType.NVarChar).Value = txt_stock_no.Text;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = txt_qty.Text;
            command.Parameters.Add("@Item_Description", SqlDbType.NVarChar).Value = combo_itemk_description.Text;
            command.Parameters.Add("@Item_Type", SqlDbType.NVarChar).Value = combo_item_type.Text;
            command.Parameters.Add("@No_of_Gems", SqlDbType.Int).Value = txt_no_of_gems.Text;
            command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar).Value = txt_gem_type.Text;
            using (MemoryStream ms = new MemoryStream())
            {
              pb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
              command.Parameters.Add("@Image", SqlDbType.Image).Value = ms.ToArray();
            }
            command.ExecuteNonQuery();
    
            MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        conn.Close();
    
        this.Close();
    }
