    using (var context = new DbContext())
    {
        var query = from u in context.Users
                    join c in context.Car on u.CarId equals c.CarId
                    select new User 
                    {
                        UserId = u.UserId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Car = new Car()
                        { CarId = c.CarId, Name = c.Name } 
                    }
    }
