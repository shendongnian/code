    Date ter = new Date()
    {
        StartTime = dto.StartTime,
        EndTime = dto.EndTime,
        Name = dto.Name,
        Place = dto.Place,
        //Datetype = tera,
        DatetypeId = tera.DatetypeId,
        Type = dto.Type,
        //Squad = new Squad(),
        TeamNumber = mannschaft.Id
    };
    uow.RepDate.Create(ter);
    //mannschaft.Dates.Add(ter);
    uow.SaveChanges();
