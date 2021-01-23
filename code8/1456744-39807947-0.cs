      string Json2 = @"{'Id':1, 'FirstName':'John', 'LastName':'Smith'}";
      dynamic dJson2 = JsonConvert.DeserializeObject(Json2);
      dJson2.Type = "mynewfield";
      Console.WriteLine(dJson2.GetType());
      Console.WriteLine(dJson2.Type);
