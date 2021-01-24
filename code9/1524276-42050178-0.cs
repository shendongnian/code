     public class DetailInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class Info
        {
            public DetailInfo Detail { get; set; }
            public int InfoId { get; set; }
            public DateTime InfoDate { get; set; }
            public double Value { get; set; }
    
            public int Week { get; set; }
        }
    
    public List<Info> RefineData(List<Info> listOfInfo)
            {
                var orderedAndRefinedData = listOfInfo
                                        .OrderBy(p => p.InfoDate)
                                        .Select(p =>
                                                  new Info
                                                  {
                                                      Detail    = p.Detail,
                                                      InfoId    = p.InfoId,
                                                      InfoDate  = p.InfoDate,
                                                      Value     = p.Value,
                                                      Week      = WeekOfYear(p.InfoDate)
                                                  }).ToList();
    
                var duplicateDataListInWeek = orderedAndRefinedData
                                                .GroupBy(p => new { p.Week, p.Value })
                                                .SelectMany(grp => grp.Skip(1));
    
                foreach (var dataItem in duplicateDataListInWeek)
                {
                    dataItem.Value = 0;
                }
    
                return orderedAndRefinedData;
            }
    
            public static int WeekOfYear(DateTime date)
            {
                var day = (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
                return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)),
                                                                        CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
