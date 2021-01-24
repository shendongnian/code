	SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings
	["connectToEnterpriseAssignmentDB"].ToString());
					SqlCommand cmd1 = new SqlCommand();
					string currency = lstCurrency.SelectedItem.Value.ToString();
					string columnCurr = lstColumnCurr.SelectedItem.Value.ToString();
					double value = double.Parse(txtValue.Text);
					currency= currency.Trim();
					columnCurr=columnCurr.Trim();         
					cmd1.CommandText = "UPDATE CurrencyTbl SET "+columnCurr + " = '@Value' WHERE CurrencyName = '@Currency'";
					cmd1.Parameters.Add("@Currency", SqlDbType.Char).Value = currency;
					//cmd1.Parameters.Add("@Column", SqlDbType.Char).Value = columnCurr;
					cmd1.Parameters.Add("@Value", SqlDbType.Float).Value = value;
					cmd1.Connection = connect;
					connect.Open();
					cmd1.ExecuteNonQuery();
					connect.Close();
