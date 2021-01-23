    string paisa;
	private void load_commission_setup()
	{
		using (SqlCeConnection con = new SqlCeConnection(@"Data Source=|DataDirectory|\Database.sdf;Persist Security Info=False"))
		{
			con.Open();
			using (SqlCeCommand cmd = new SqlCeCommand(@"SELECT Paisa FROM CommissionSetupTable WHERE=@gross BETWEEN FromRate AND ToRate;", conn))
			{
				cmd.Parameters.Add("@gross", DbType.Double).Value = gross_amount;
				using (SqlCeDataReader rdr = cmd.ExecuteReader())
				{
					try
					{
						if (rdr != null)
						{
							while (rdr.Read())
							{
								paisa = rdr["Paisa"].ToString();
							}
						}
					}
					finally
					{
						conn.Close();
						int rowindex = purchaseBillTableDataGridView.Rows.Count - 1;
						purchaseBillTableDataGridView[11, rowindex].Value = paisa;
					}
				}
			}
		}
	}
