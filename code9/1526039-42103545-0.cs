    lstRecord = (from a in lstPerson
             select new GeneralCommonFunctions.MemberDetailSumary
             {
               Age = DateTimeUtility.GetCurrentAge(a.Dob),
             }).Select(t=>new GeneralCommonFunctions.MemberDetailSumary{
                          Age=t.Age,
                          AgeGroupID = t.Age<=25?1:t.Age<=35?2:t.Age<=45?3:t.Age<=55?4:5,
                      }).ToList();
