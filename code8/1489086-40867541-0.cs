    int room_qty = 2; // <-- this comes from user input
    List<string> rooms = new List<string>();
    roomtype = "Carneros Inn";
    SqlCommand cmd = new SqlCommand("FindRoom", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("@ROOM_TYPE", SqlDbType.VarChar).Value = roomtype;
    conn.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    while(reader.Read())
    {
        rooms.Add(reader["room_id"].ToString());
        Console.WriteLine("Selected room ID = " + roomID);
        // We have reached the requested quantity????
        if(rooms.Count == room_qty)
           break;
    }
    conn.Close();
    if(rooms.Count < room_qty)
        Console.WriteLine("Not enough room available!");
