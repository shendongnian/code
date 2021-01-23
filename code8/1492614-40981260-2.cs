	SqlCommand command = new SqlCommand(
		"INSERT INTO profiles(userName, name, lastName, password, birthYear, birthMonth, birthDay, gender, email)" +
		"VALUES(@userName, @name, @lastName, @password, @birthYear, @birthMonth, @birthDay, @gender, @email)"
		, connect);
	command.Parameters.Add("@userName", SqlDbType.NChar, 10).Value = user_name;
	command.Parameters.Add("@name", SqlDbType.NChar, 10).Value = name;
	command.Parameters.Add("@lastName", SqlDbType.NChar, 10).Value = last_name;
	command.Parameters.Add("@password", SqlDbType.NChar, 10).Value = password;
	command.Parameters.Add("@birthYear", SqlDbType.Int).Value = year;
	command.Parameters.Add("@birthMonth", SqlDbType.Int).Value = month;
	command.Parameters.Add("@birthDay", SqlDbType.Int).Value = day;
	command.Parameters.Add("@gender", SqlDbType.Bit).Value = gender;
	command.Parameters.Add("@email", SqlDbType.NChar, 10).Value = email;
