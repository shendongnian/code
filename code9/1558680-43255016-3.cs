    //format your IN query
	string[] paramArray = rollMarks.Select(x, i) => "@settings" + i).ToArray();
	string query = string.Format("select * from  student_details where roll_number IN ({0})", string.Join(",", paramArray));
	SqlDataAdapter da = new SqlDataAdapter(query, con);
	DataTable dt = new DataTable();
	for (int i = 0; i < rollMarks.Count(); ++i)
	{
		da.SelectCommand.Parameters.AddWithValue("@settings", rollMarks[i].roll_number)
	}
	da.Fill(dt);
