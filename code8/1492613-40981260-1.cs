	SqlCommand command = new SqlCommand(
		"INSERT INTO profiles(userName, name, lastName, password, birthYear, birthMonth, birthDay, gender, email)" +
		"VALUES(@userName, @name, @lastName, @password, @birthYear, @birthMonth, @birthDay, @gender, @email)"
		, connect);
	command.Parameters.Add("@userName", SqlDbType.VarChar).Value = user_name;
	command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
	command.Parameters.Add("@lastName", SqlDbType.VarChar).Value = last_name;
	command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
	command.Parameters.Add("@birthYear", SqlDbType.Int).Value = year;
	command.Parameters.Add("@birthMonth", SqlDbType.Int).Value = month;
	command.Parameters.Add("@birthDay", SqlDbType.Int).Value = day;
	command.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender ? "1" : "0";
	command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
