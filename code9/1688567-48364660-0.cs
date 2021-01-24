      var tempMOList = new List<int>();
                    tempMOList = newTrendChart.Monitors.Select(x=> x.MOParameterId).ToList();
                    foreach (var id in tempMOList)
                    {
                        var temp = newTrendChart.Monitors.Where(x => x.MOParameterId == id).FirstOrDefault();
                        if (trendChart.Monitors.Any(x => x.MoParameterId == id) == false)
                            newTrendChart.Monitors.Remove(temp);
    
                    }
    
                    foreach (var item in trendChart.Monitors)
                    {
                        if (newTrendChart.Monitors.Any(x => x.MOParameterId == item.MoParameterId) == false)
                            newTrendChart.Monitors.Add(new DataAccess.ParameterMonitor { MOParameterId = item.MoParameterId });
                    }
    
                    //prevent from adding new parameter
                    foreach (var item in newTrendChart.Monitors)
                    { 
                        db.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
                    }
        db.SaveChanges();
