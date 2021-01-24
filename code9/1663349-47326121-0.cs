    SqlCommand cmd = new SqlCommand(@"INSERT INTO [Order] (buyersName, deliveryAddress, productID, productName, category, image, price, paymentMode, holderName) 
                                      VALUES(@buyersName, @deliveryAddress, @productID, @productName, @category, @image, @price, @paymentMode, @holderName)", con);
	cmd.Parameters.Add("@buyersName", SqlDbType.VarChar).Value = Label2.Text;
	cmd.Parameters.Add("@deliveryAddress", SqlDbType.VarChar).Value = TextBox1.Text;
	cmd.Parameters.Add("@productID", SqlDbType.VarChar).Value = g1.Cells[0].Text;
	cmd.Parameters.Add("@productName", SqlDbType.VarChar).Value = g1.Cells[1].Text;
	cmd.Parameters.Add("@category", SqlDbType.VarChar).value = g1.Cells[2].Text;
	cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value =  g1.Cells[3].Text; //convert g1.Cells[3].Text to a byte array
	cmd.Parameters.Add("@price", SqlDbType.Money) = g1.Cells[4].Text;
	cmd.Parameters.Add("@paymentMode", SqlDbType.VarChar).Value = checkRadioButton();
	cmd.Parameters.Add("@holderName", SqlDbType.VarChar).Value = TextBox2.Text;
	int r=cmd.ExecuteNonQuery();
