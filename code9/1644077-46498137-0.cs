        public LocationViewModel()
        {
            var db = new DailyEntities();
            // Get the month from the date picker
            var month = 0;
            int.TryParse(MDate.ToString("MM"), out month);
            Efficiency = Convert.ToDecimal(db.LocationKPI.Where(a => a.sMonth == month).Select(a => a.Efficiency).FirstOrDefault());
        }
