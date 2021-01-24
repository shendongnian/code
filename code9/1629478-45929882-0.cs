    public  static IList<SelectionDailyReport> GetSelectionData (DateSearchRange DateSearchRange, CrewLogContext context) {
        var myList =  context.TaskSelection.Where(x => x.WorkDate >=DateSearchRange.StartDate && x.WorkDate <= DateSearchRange.EndDate)
                .Include(t => t.Zone).OrderBy(x => x.AssocId).ToList();
         return  myList ;
       }
