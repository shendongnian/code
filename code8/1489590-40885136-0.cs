         PropertyInfo[] placeTypes;
            placeTypes = typeof(PlaceType).GetProperties(BindingFlags.Public |
                                                      BindingFlags.Static);
    var requestedType = placeTypes.SingleOrDefault(x=> x == request.PlaceType);
    
    PropertyInfo context = typeof(dbContext).GetPropertie(requestedType.Name + "s");
        
    var place = context.Include(d => d.Reservations).FirstOrDefault(d => d.Id == request.PlaceId);
            place?.Reservations.Add(request.ToReservation(userId));
