    var innerJoinQuery =
        from car in cars
        join part in parts on car.Id equals part.CarId
        join subPart in subParts on part.Id equals subPart.PartId
        select new {
            CarId = car.Id, 
            CarName = car.Name,
            PartsId = part.Id,
            PartsName = part.Name,
            SubPartsId = subPart.Id,
            SubPartsName = subPart.Name
        };
