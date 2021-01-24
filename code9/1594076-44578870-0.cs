	// find records that extend an earlier record
	var step0 = from r1 in src
				join r2 in src.Skip(1) on new { r1.CustomerId, TestDate = r1.EndDateTime.AddDays(1) } equals new { r2.CustomerId, TestDate = r2.EffectiveDateTime }
				select new { r1, r2 };
	// combine extended records and passthru non-extended records
	var step1 = (from r1 in src
				where !step0.Any(r1r2 => r1 == r1r2.r1)
				join r1r2 in step0 on r1 equals r1r2.r1 into r1r2j
				from r1r2 in r1r2j.DefaultIfEmpty()
				let r2 = r1r2?.r2
				orderby r1.CustomerId, r1.EffectiveDateTime
				select new CustomerMembership { CustomerId = r1.CustomerId, EffectiveDateTime = r1.EffectiveDateTime, EndDateTime = (r2 != null) ? r2.EndDateTime : r1.EndDateTime }).ToArray();
	// find bad records by comparing records to previous record
	for (var j1 = 1; j1 < step1.Length; ++j1)
		if (!step1[j1-1].IsBad)
			step1[j1].IsBad = step1[j1].CustomerId == step1[j1-1].CustomerId &&
				(step1[j1].EffectiveDateTime.IsBetween(step1[j1-1].EffectiveDateTime, step1[j1-1].EndDateTime) ||
				step1[j1].EndDateTime.IsBetween(step1[j1-1].EffectiveDateTime, step1[j1-1].EndDateTime));
		
	var ans = step1.ToList();
