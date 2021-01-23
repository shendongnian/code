    DBSet<IPlace> dbSet = null;
    if (request.PlaceType == PlaceType.Doctor)
        dbSet = db.Doctors;
    else if (request.PlaceType == PlaceType.Hospital)
        dbSet = db.Hospitals;
    if (dbSet == null) throw new Exception("Unsupported PlaceType");
    var place = dbSet.Include(d => d.Reservations).FirstOrDefault(d => d.Id == request.PlaceId);
    place?.Reservations.Add(request.ToReservation(userId));
