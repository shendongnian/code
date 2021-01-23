     var b = Builders<SomeClass>.Filter;
     var date = DateTime.UtcNow.Date;
     var filter = b.And(
            b.Gte(x => x.SomeDateTimeProperty, date), 
            b.Lt(x => x.SomeDateTimeProperty, date.AddDays(1))
            );
     ...
