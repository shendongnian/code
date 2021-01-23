    static class RecordFactory
    {
        private delegate DateTime TimeGetterFunction(Store s);
        static object New(Store store, DayOfWeek weekDay)
        {
            var timeOpen = new Dictionary<DayOfWeek, TimeGetterFunction>();
            timeOpen.Add(DayOfWeek.Monday, (s) => s.mondayOpen);
            timeOpen.Add(DayOfWeek.Tuesday, (s) => s.tuesdayOpen);
            var timeClose = new Dictionary<DayOfWeek, TimeGetterFunction>();
            timeClose.Add(DayOfWeek.Monday, (s) => s.mondayClose);
            timeClose.Add(DayOfWeek.Tuesday, (s) => s.tuesdayClose);
            return new { 
                TimeOpen = timeOpen[weekDay](store), 
                TimeClose = timeClose[weekDay](store) 
                //Add more properties...
            };
        }
    }
    // in your Linq query...
    select RecordFactory.New(DayOfWeek.Monday, s);
