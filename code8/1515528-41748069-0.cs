    public static class DropdownData
    {
        public static IList<SelectListItem> GetTimeList()
        {
            var times = new List<SelectListItem>();
            times = Enumerable.Range(4, 4).Select(x => {
                var minute = x * 15;
                var time = DateTime.Today.AddMinutes(minute);
                return new SelectListItem()
                {
                    Value = minute.ToString(),
                    Text = time.ToString("hh:mm tt")
                };
            }).ToList();
            return times;
        }
    }
