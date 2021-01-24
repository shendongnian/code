            //convert the data using a projection query
            var query1 = from data in _data
                         let inceptTime = DateTimeOffset.ParseExact(data.Field<string>("Incept Time"), "yyyy-MM-ddTHH:mm:sszzzz", CultureInfo.InvariantCulture)
                         let editTime = DateTimeOffset.ParseExact(data.Field<string>("Edit Time"), "yyyy-MM-ddTHH:mm:sszzzz", CultureInfo.InvariantCulture)
                         let difference = editTime - inceptTime
                         select new
                         {
                             name = data.Field<string>("Name"),
                             caseId = data.Field<string>("Case ID"),
                             inceptTime,
                             editTime,
                             difference
                         };
            //group by caseID (also by NAME, but that won't matter for this grouping and is needed in query3)
            var query2 = from data in query1
                         group data by new { data.caseId, data.name } into groups
                         let min = groups.Min(x => x.inceptTime)
                         let max = groups.Max(x => x.editTime)
                         select new
                         {
                             name = groups.Key.name,
                             caseId = groups.Key.caseId,
                             min,
                             max,
                             diff = max - min
                         };
            
            //now group by name
            var query3 = from data in query2
                         group data by new { data.name } into groups
                         select new
                         {
                             name = groups.Key.name,
                             minDiff = groups.Min(x => x.diff),
                             maxDiff = groups.Max(x => x.diff),
                             avgDiff = new TimeSpan((long)groups.Average(x => x.diff.Ticks)),
                         };
