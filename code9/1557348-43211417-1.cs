        public ActionResult AllSummaries(int? page, int? month, int? day, int? year)
        {
            var yesterday = DateTime.Today.AddDays(-1); // default
            if (month.HasValue && day.HasValue && year.HasValue)
            {
                yesterday = new DateTime(year.Value, month.Value, day.Value);
            }
