    var service = AnalyticsService AuthenticateServiceAccount(.....);
    DataResource.GaResource.GetRequest request = service.Data.Ga.Get(
                   "ga:" + websiteCode,
                   DateTime.Today.AddDays(-15).ToString("yyyy-MM-dd"),
                   DateTime.Today.ToString("yyyy-MM-dd"),
                   "ga:sessions");
                request.Dimensions = "ga:year,ga:month,ga:day";
                var data = request.Execute();
    
                foreach (var row in data.Rows)
                {
                    visitsData.Add(new ChartRecord(new DateTime(int.Parse(row[0]), int.Parse(row[1]), int.Parse(row[2])).ToString("MM-dd-yyyy"), int.Parse(row[3])));
                }
