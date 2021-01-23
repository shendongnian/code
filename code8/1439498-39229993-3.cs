    obj = (from xmlsummary in doc.Descendants("summary")
           group xmlsummary by new { id = xmlsummary.Element("providerid").Value, period = xmlsummary.Element("period").Value } into summaryGrouped
           select
              new UsageSummary{
                    carrierID = Convert.ToInt16(summaryGrouped.Key.id),
                    period = summaryGrouped.Key.period,
                    sms = (summaryGrouped.Where(sg => sg.Element("type").Value.Equals("1")).Select(v => Convert.ToInt64(v.Element("volume").Value)).Sum()),
                    minutes = (summaryGrouped.Where(sg => sg.Element("type").Value.Equals("2")).Select(v => Convert.ToInt64(v.Element("volume").Value)).Sum()),
                    data = (summaryGrouped.Where(sg => sg.Element("type").Value.Equals("3")).Select(v => Convert.ToInt64(v.Element("volume").Value)).Sum())
                   }
          ).ToList();
