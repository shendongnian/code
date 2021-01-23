    var UsageSummaryList = 
          (from summary in
            (from xmlsummary in doc.Descendants("summary")
             group xmlsummary by new { id = xmlsummary.Element("providerid").Value, period = xmlsummary.Element("period").Value } into summaryGrouped
             select new
             {
               id = summaryGrouped.Key.id,
               period = summaryGrouped.Key.period,
               data = summaryGrouped.ToDictionary(d => d.Element("type").Value, k => k.Element("volume").Value)
             }
            )
           select new UsageSummary
           {
             carrierID = Convert.ToInt16(summary.id),
             period = summary.period,
             sms = summary.data.ContainsKey("1") ? Convert.ToInt64(summary.data["1"]) : -1,
             minutes = summary.data.ContainsKey("2") ? Convert.ToInt64(summary.data["2"]) : -1,
             data = summary.data.ContainsKey("3") ? Convert.ToInt64(summary.data["3"]) : -1
           }
          ).ToList();
