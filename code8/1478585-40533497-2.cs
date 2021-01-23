    var user = new UserModel
    {
        Name = reader.GetString(reader.GetOrdinal("Name")),
        CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))   
    }
    if(!reader.IsDBNull(reader.GetOrdinal("LastUpdatedDate")))
    {
      user.LastUpdatedDate = reader.GetDateTime(reader.GetOrdinal("LastUpdatedDate"));
    }
 
