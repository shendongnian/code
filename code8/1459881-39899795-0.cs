            var CProcess = (from m in DataContext.csrcallds.AsEnumerable()
                            where m.scheduledon >= earliestDate
                            && m.scheduledon <= objdate1.DateStart
                            && m.calltype == "CHQRUN"
                            && (SqlMethods.DateDiffDay(FluentDateTime.DateTimeExtensions.AddBusinessDays((DateTime)m.scheduledon, 2), m.completedon) > 2)
                            group m by new { m.scheduledon.Value.Year, m.scheduledon.Value.Month } into p
                            orderby p.Key.Year ascending, p.Key.Month ascending
                            select new Date1()
                            {
                                theDate = DateTime.Parse($"{p.Key.Month} - {p.Key.Year}"),
                                theCount = p.Count(),
                                theString = $"{p.Key.Month} - {p.Key.Year}"
                            });
