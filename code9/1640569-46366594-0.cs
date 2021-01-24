    var data = db.TestRecords.ToList();
    
    IEnumerable<MyMainViewModel> model = data.GroupBy(x => x.Section.SectionName).Select(y => new MyMainViewModel(){  
         Location = y.Key,
         Children = y.Select(z => new MyChildViewModel(){
              Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(z.DateEntered.Month),
              Year = z.DateEntered.Year.ToString(),
              TotalPhoneCalls = y.Where(t => t.Section.SectionName == z.Section.SectionName).Sum(t => t.PhoneCallsTaken)
         }).Distinct()
     });
