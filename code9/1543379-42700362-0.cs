    command.Parameters.Add("@cat", SqlDbType.VarChar, 2).Value = category;
    command.Parameters.Add("@veg", SqlDbType.Int).Value = vegetarianFriendlyMeal;
    if (calories == null)
    {
        command.Parameters.Add("@calories", SqlDbType.Int).Value = (object)DBNull.Value;
    }
    else
    {
        command.Parameters.Add("@calories", SqlDbType.Int).Value = calories;
    }
