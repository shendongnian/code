    var result = GetYearInfoData()
        .Where(d => d.CreateDt < DateTime.Now)
        .Select(x => x.RecordId)                                   // RecordIds 1, 1, 1, 5, 5, 6
        .Distinct()	                                                        // RecordIds 1, 5, 6
        .Join(GetMainRecordInfoData(), i => i, r => r.RecordId, (i, r) => r.UserId)	 // UserIds 1, 2, 2
        .Join(GetUserInfoData()      , i => i, u => u.UserId  , (i, u) => u.Name  )	 // Names { Patrick, Stacy, Stacy }
    	.GroupBy(n => n)
        .Select(g => new { Name = g.Key, Count = g.Count() });	// Names and Counts
