    var defaultDate = DateTime.MinValue;
    EnrolmentList.AddRange(_query.Select(item => new EnrolmentEntity
        {
            PeopleUnitsID = item.PeopleUnitsID,
            PersonCode = item.PersonCode,
            UnitType = item.UnitType,
            ProgressCode = item.ProgressCode,
            ProgressStatus = item.ProgressStatus,
            ProgressDate = item.ProgressDate == null ? defaultDate : Convert.ToDateTime(item.ProgressDate),
            UnitInstanceID = item.UnitInstanceID,
            UnitInstanceOccurrenceID = item.UnitInstanceOccurrenceID,
            CourseCode = item.CourseCode,
            OwningOrganisation = item.OwningOrganisation,
            CalendarOccurrenceCode = item.CalendarOccurrenceCode,
            FES_Start_Date = item.FES_Start_Date == null ? defaultDate : Convert.ToDateTime(item.FES_Start_Date),
            AimStartDate = item.AimStartDate == null ? defaultDate : Convert.ToDateTime(item.AimStartDate)
        }));
