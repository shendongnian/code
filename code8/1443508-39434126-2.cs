    public class OccupancyTimelineHelper : EnumHelper<OccupancyTimeline>
    {
        public override string EnumToString(occupancyTimeline value)
        {
            switch (value)
            {
                case OccupancyTimelineHelper.TwelveMonths:
                    return "12 Month";
                case OccupancyTimelineHelper.FourteenMonths:
                    return "14 Month";
                case OccupancyTimelineHelper.SixteenMonths:
                    return "16 Month";
                case OccupancyTimelineHelper.EighteenMonths:
                    return "18 Month";
                default:
                    return base.EnumToString(value);
            }
        }
    }
