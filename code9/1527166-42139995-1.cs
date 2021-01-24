    DateTime dt;
    if(!DateTime.TryParse(thetime_insert.Text, out dt);
        // Message, not a valid date....
    else
      command.Parameters.Add("@thetime", MySqlDbType.Date).Value = dt;
