    var tblYearInfoData = GetYearInfoData();
    
    var tblMainRecordInfoData = GetMainRecordInfoData();
    
    var tblGetUserInfoData = GetUserInfoData();
    
    var thisWillNeverWork = (from yfd in tblYearInfoData
                            where yfd.CreateDt < DateTime.Now // Pull all the record ids where the create dt is out of date... i.e.  in the past...
                            select new
                            {
                                RecordId = yfd.RecordId  // Select those record ids....
                            })
                            .GroupBy(gb => gb.RecordId) // Now group by the record ids... so if there is one record id.... and there are 3 that are out of date... it will combine it to 1...
                            .Select(selectGroup1 => new
                            {
                               RecordId = selectGroup1.Key, // This will get the grouped by record ids...
    
                                // Get the User Id so then we can do a final count with the name
                                UserId = tblMainRecordInfoData.Where(w => w.RecordId == selectGroup1.Key).Select(s => s.UserId).FirstOrDefault() 
                            }).GroupBy(gb => gb.UserId) // Then we group by user id....
                              .Select(selectGroup2 => new ReportOutOfDateCountDto
                              {
                                 Name = tblGetUserInfoData.Where(w => w.UserId == selectGroup2.Key).Select(s => s.Name).FirstOrDefault(),  // we use the user id grouped by... to get the name
                                 CountOfOutOfDateYearNbrs = selectGroup2.Count()  // then we do a count on the group by and somehow it worked... haha not sure how :-)
                              }).ToList();
