    lstRecord = (from a in lstPerson
                 select new GeneralCommonFunctions.MemberDetailSumary
                 {
                   Age = DateTimeUtility.GetCurrentAge(a.Dob),
                   AgeGroupID = GetAgeGroup(a.Dob);
    
     }).ToList();
