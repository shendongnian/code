	string sql = "select userid,logdate from Devicelogs_1_2015 where LogDate between @fdate and @tdate";
	using(SqlConnection sqlcon = new SqlConnection(sqlconf))
	using(SqlCommand sqlcom = new SqlCommand(sql, sqlcon))
	{
		sqlcom.Parameters.Add("@fdate", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
		sqlcom.Parameters.Add("@tdate", SqlDbType.Date).Value = dateTimePicker2.Value.Date;
		
		sqlcon.open();
		// rest of the code that executes the query etc.
	}
