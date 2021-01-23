	public void saverecd(string id, string particular,string amt,string tdate, string total, string date, string utrno, string modeofpayment, string transferdate,string trainer, string typeofadj)
	{
		List<string> sp = particular.split(',');
		foreach(string s in sp)
		{
			using (SqlConnection connection = new SqlConnection(/* connection info */))
			{
				sqlq = "insert into finalinstructoreexpense(sonvinid,particulars,amount,totalamt,date,utno,paymentid,paymode,issuedate,sondate,trainer,type,bank_id) values(@id,@s,@amt,@total,@dt,@utrno,@paymentid,@modeofpayment,@transferdate,@tdate,@trainer,@typeofadj,null)";
				connection.Open();
				using (SqlCommand comm1 = new SqlCommand(sql, connection))
				{
					comm1.Parameters.Add("@id",SqlDbType.Int).value=id;
					comm1.Parameters.Add("@s",SqlDbType.Varchar, 50).value =s;
					comm1.Parameters.Add("@amt",SqlDbType.Varchar, 50).value =s;
					comm1.Parameters.Add("@trainer",SqlDbType.Varchar, 50).value =trainer;
					comm1.Parameters.Add("@dt", SqlDbType.Date).Value = date;
					comm1.ExecuteNonQuery();
					message = "Adjusted Amount Inserted Successfully";
					Context.Response.Write(message);
				}
			}
		}
	}
