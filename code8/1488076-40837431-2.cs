	if (Inventory.passQty == "1")
	{
		SqlConnection connection = new SqlConnection("Data Source = DESKTOP-ANJELLO\\SQLEXPRESS; Initial Catalog = db_ADAPurchase; Persist Security Info = True; User Id = sa; Password = mm4;");
		connection.Open();
		SqlCommand cmd = new SqlCommand();
		cmd.Connection = connection;
		cmd.CommandType = CommandType.Text;
		cmd.CommandText = String.Format("SELECT * FROM tbl_PurchaseRequest WHERE request_id = {0}", Inventory.passID);
		SqlDataReader dr = cmd.ExecuteReader();
		if (dr.Read())
		{
			label_RID.Text = dr.GetString(0);
			label_Item1.Text = dr.GetString(1);
			txb_Title.Text = dr.GetString(2);
			cbx_vendor.Text = dr.GetString(3);
			txb_address.Text = dr.GetString(4);
			label_date.Text = dr.GetString(5);
			cbx_terms.Text = dr.GetString(6);
			label_total.Text = dr.GetSqlInt32(12).ToString();
			txb_reqBy.Text = dr.GetString(13);
			int number = 1;
			do
			{
				TextBox tb = this.Controls.Find("txb_ITD" + number.ToString(), true).FirstOrDefault() as TextBox;
				tb.Text = dr.GetString(7);
				TextBox tb1 = this.Controls.Find("txb_Qty" + number.ToString(), true).FirstOrDefault() as TextBox;
				tb1.Text = dr.GetSqlInt32(8).ToString();
				TextBox tb2 = this.Controls.Find("label_unit" + number.ToString(), true).FirstOrDefault() as TextBox;
				tb2.Text = dr.GetString(9);
				TextBox tb3 = this.Controls.Find("txb_UntP" + number.ToString(), true).FirstOrDefault() as TextBox;
				tb3.Text = dr.GetSqlInt32(10).ToString();
				TextBox tb4 = this.Controls.Find("txb_TotP" + number.ToString(), true).FirstOrDefault() as TextBox;
				tb4.Text = dr.GetSqlInt32(11).ToString();
				number++;
				//Since Query can pull more records than 10
				if(number>=10)
				{
					break;
				}
			}
			while(dr.Read())
		}
		connection.Close();
	}
	
