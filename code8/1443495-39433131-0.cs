    public enum occupancyTimeline:int {
        TwelveMonths=12,
        FourteenMonths=14,
        SixteenMonths=16,
        EighteenMonths=18
    }
    
    public static class MyExtensions {
        public static SelectList ToSelectList<occupancyTimeline>(this occupancyTimeline enumObj)
        {
            var values = from occupancyTimeline e in Enum.GetValues(typeof(occupancyTimeline))
                            select new { Id = e, Name = string.Format("{0} Months",Convert.ToInt32(e)) };
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
