    var groups = (from a in db.AUsers
                  // Your query...
                  select new Group
                  {
                      // Properties of Group
                      Name = g5.Name,
                      AnotherProperty = g5.AnotherProperty
                  }).ToList();
