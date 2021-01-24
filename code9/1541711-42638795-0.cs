    public class SearchVM
    {
      public IEnumerable<YearSummary> YearSummary { get; set; }
      public IEnumerable<TrainingQ> Training { get; set; }
    }
    public ActionResult Search(int? id)
    {
        var model = new SearchVM
        {
          YearSummary = (from ti in db.TrainingRecordDBSet
                          join si in db.StaffInfoDBSet
                               on ti.StaffId equals si.StaffId
                          group ti by ti.Year into g
                          select new {
                              Year = g.Key,
                              SHour = g.Sum(ti => ti.Hour)
                          })
            .AsEnumerable()
            .Select(ys => new YearSummary { Year = ys.YEar, SHour = ys.Shour {)
            .ToList(),
          TrainingQ = (from t in db.TrainingRecordDBSet.Include("StaffInfo")
                        where t.StaffId == id orderby t.StaffId, t.Tid
                        select t)
            .ToList()
        };
        return View(model);
    }
