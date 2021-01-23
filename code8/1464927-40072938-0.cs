    while (reader.Read())
      {
          var Place = new Place();
          Place.ID = Convert.ToInt32(reader["id"]);
          Place.Name = reader["name"].ToString();
          Place.Address = reader["address"].ToString();
          Place.City = reader["city"].ToString();
          Place.Category = reader["category"].ToString();
    
          listOfPlace.Add(Place);
      }
