        public IEnumerable<SelectListItem> ReverseMonthsLists()
        {
            var selectListItems = GetDates()
                .Select(_ => _.ToString("MMM yyyy"))
                .Select((dateString, index) => new SelectListItem {  Selected = index == 0, Text = dateString, Value = dateString})
                .ToList();
            return selectListItems;
        }
