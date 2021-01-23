    var user = new UserModel
    {
        EmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress")),
        CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"))   
    }
    if(!reader.IsDBNull(reader.GetOrdinal("LastUpdatedDate")))
    {
      user.LastUpdatedDate = reader.GetDateTime(reader.GetOrdinal("LastUpdatedDate"));
    }
 
