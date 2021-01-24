    Private Void SaveEdits_Click()
    {
     using (SqlConnection con = new SqlConnection(mycon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE Customers set firstname= @FN , lastname= @LN , age = @AG , postcode= @PC where CustomerID = @CustID";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@CustID", cid);
                    cmd.Parameters.AddWithValue("@FN", tb_editFirstName.Text);
                    cmd.Parameters.AddWithValue("@LN", tb_editLastName.Text);
                    cmd.Parameters.AddWithValue("@AG", tb_editAge.Text);
                    cmd.Parameters.AddWithValue("@PC", tb_editPostCode.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            CustomersBindGrid();
            MessageBox.show("Information Updated!");
       }
    }
