    var pipeline = 
          collection.
                Aggregate()
                  .Project(
                     p => new {
                      PartData= p.PartData.Where(d => d.Description == specifiedDescription),
                      SensorData= p.SensorData.Where(s=> s.Description == specifiedDescription)
                }
          );
