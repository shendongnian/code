    foreach (var item in _query)
            {
                EnrolmentList.Add(new EnrolmentEntity
                {
                    PeopleUnitsID = item.PeopleUnitsID,
                    PersonCode = item.PersonCode,
                    UnitType = item.UnitType,
                    ProgressCode = item.ProgressCode,
                    ProgressStatus = item.ProgressStatus,
                    ProgressDate = item.ProgressDate.GetValueOrDefault(),
                    UnitInstanceID = item.UnitInstanceID,
                    UnitInstanceOccurrenceID = item.UnitInstanceOccurrenceID,
                    CourseCode = item.CourseCode,
                    OwningOrganisation = item.OwningOrganisation,
                    CalendarOccurrenceCode = item.CalendarOccurrenceCode,
                    FES_Start_Date = item.FES_Start_Date.GetValueOrDefault(),
                    AimStartDate = item.AimStartDate.GetValueOrDefault()
                });
            }
