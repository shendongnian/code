	const string sql = @"INSERT INTO stollar (id, table_no, gametime, localdate,  money) VALUES (@id, @table_no, @gametime, @localdate, @money)";
	using(SqlConnection conn = new SqlConnection(/*your connection string from app.config or web.config*/))
	using(SqlCommand cmd = new SqlCommand(sql, conn))
	{
		cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int){Value = int.Parse(txt1.Text)});
		cmd.Parameters.Add(new SqlParameter("@table_no", SqlDbType.VarChar, 100){Value = gbox1.Text.Trim()});
		cmd.Parameters.Add(new SqlParameter("@gametime", SqlDbType.Time){Value = TimeSpan.FromMinutes(int.Parse(time_hour.Text.Trim()) * 60 + int.Parse(time_minute.Text.Trim()))});
		cmd.Parameters.Add(new SqlParameter("@localdate", SqlDbType.DateTime){Value = DateTime.Now});
		cmd.Parameters.Add(new SqlParameter("@money", SqlDbType.Decimal){Precision = 10, Scale = 2, Value = decimal.Parse(txtbox_1.Text, CultureInfo.InvariantCulture)});
		conn.Open();
		cmd.ExecuteNonQuery();
	}
