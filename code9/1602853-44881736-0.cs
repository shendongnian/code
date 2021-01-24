      var query = Query.And(Query.EQ("Id", carId), 
      Query.EQ("Drivers.IsActive", 
      "true"));
      MongoCursor<Car> cursor = carCollection.FindAs<Car>(query);
      if (cursor.Count() > 0 && cursor.ToList()[0].Drivers != null)
      {
         // use the cursor.ToList()[0].Drivers 
       }
            
