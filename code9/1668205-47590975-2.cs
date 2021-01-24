    // query here is complete
    var result = query.AsEnumerable().Select(c => {
        new CarDto {
            ID = c.ID,
            Description = c.Description,
            // etc
        }
    });
