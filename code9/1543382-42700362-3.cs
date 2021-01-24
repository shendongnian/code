    command.Parameters.Add("@cat", SqlDbType.VarChar, 2).Value = category;
    command.Parameters.Add("@veg", SqlDbType.Int).Value = vegetarianFriendlyMeal;
    SqlParameter cal = new SqlParameter("@calories", calories == null ? (object)DBNull.Value : calories);
    cal.DbType = SqlDbType.Int;
    command.Parameters.Add(cal);
