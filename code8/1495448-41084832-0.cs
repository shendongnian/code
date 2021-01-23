    // This list will store all the records retrieved
    List<User> usersList = new List<User>();
    string cmdText = "SELECT * FROM user INNER JOIN user_media ON user.id = user_media.user_id";
    using(MySqlConnection con = new MySqlConnection(.....))
    using(MySqlCommand cmd = new MySqlCommand(cmdText, con))
    {
        // Starting values
        int currentUser = -1;
        User usr = null;
        con.Open();
        using(MySqlDataReader reader = cmd.ExecuteReader())
        {
            // Loop over the results till the end
            while(reader.Read())
            {
                 // If the current record is for a different user.....
                 if(reader.GetInt32("id") != currentUser)
                 {
                     // Create it
                     usr = new User();
                     // this should go in the constructor of User....
                     usr.MediaImages = new List<string>();
                     // Fill the field for the current user...
                     usr.id = reader.GetInt32("id");
                     usr.name = reader.GetString("name");
                     usr.phone = reader.GetString("phone");
                     usr.address = reader.GetString("address");
                     // Add the retrieved user to the whole list
                     userList.Add(usr);
                     // Prevent adding other elements to the list for the same user....
                     currentUser = usr.ID;
                 }
                 // For the current user add only the url info 
                 usr.MediaImages.Add(reader.GetString("media_url"));
            }
        }
    }
