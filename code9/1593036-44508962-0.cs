    var query = (from dc in DefaultMapColors
             join p in PEOCoverage_XRefs on dc.CategoryName equals p.PeoCode into p1 
             from p in p1.DefaultIfEmpty()
             join s in SutaWageBasis on p.StateCode equals s.StateAbbr into p2
             from s in p2.DefaultIfEmpty()
             where p.PeoCode == "VHR"
             select new
             {
               // snipped for brevity
             }).ToList();
