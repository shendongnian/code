    var query2 = (from s in SutaWageBasis
				  join p in PEOCoverage_XRefs on new { sc = s.StateAbbr, pc = "VHR" } equals new { sc = p.StateCode, pc = p.PeoCode } into p1
				  from p in p1.DefaultIfEmpty()
				  join dc in DefaultMapColors on p.PeoCode equals dc.CategoryName into p2
				  from dc in p2.DefaultIfEmpty()
				  select new SutaStateCoverage
				  {
					  StateAbr = s.StateAbbr,
					  StateName = s.StateName,
					  SutaBasis = s.SutaBasis ?? 0.00m,
					  ERRate = s.ERRate ?? 0.00m,
					  HighRate = s.HighRate ?? 0.00m,
					  PeoCode = p.PeoCode,
					  SutaReportingType = p.SutaReportingType,
					  SutaCost = p.SutaCost,
					  ColorValue = dc.ColorValue
				  }).ToList();
