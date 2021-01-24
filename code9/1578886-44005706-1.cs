        public class Dates
        {
            public DateTime Start {get; set;}
            public DateTime End {get; set;}
        }
        public List<Dates> FindOverlappingDates(DateTime beginPeriod, DateTime endPeriod)
        {
            var dateList = //fill in the list
        
            var dateRangesThatOverlap = datelist.Where(date =>
                     date.End > beginPeriod
                      && date.Start < endPeriod)
    
            return dateRangesThatOverlap.ToList();
        }
