    foreach (var item in _query)
       {
         EnrolmentList.Add(new EnrolmentEntity
          {
            PeopleUnitsID = item.PeopleUnitsID,
            PersonCode = item.PersonCode,
            UnitType = item.UnitType,
            ProgressCode = item.ProgressCode,
            ProgressStatus = item.ProgressStatus,
            ProgressDate = string.IsNullOrEmpty(item.ProgressDate) ? (DateTime?)null : DateTime.Parse(item.ProgressDate), 
            UnitInstanceID = item.UnitInstanceID,
            UnitInstanceOccurrenceID = item.UnitInstanceOccurrenceID,
            CourseCode = item.CourseCode,
            OwningOrganisation = item.OwningOrganisation,
            CalendarOccurrenceCode = item.CalendarOccurrenceCode,
            FES_Start_Date = string.IsNullOrEmpty(item.FES_Start_Date) ? (DateTime?)null : DateTime.Parse(item.FES_Start_Date), 
            AimStartDate = string.IsNullOrEmpty(item.AimStartDate)? (DateTime?)null :DateTime.Parse(item.AimStartDate)  
     });
