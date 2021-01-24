    internal static IReadOnlyCollection<StackChartData> GetDetails(StackChartSetting chartSetting, Func<DateTime, IConvertible> selector)
    {
        return chartSetting.StackChartDataPoints.GroupBy(x => new { TimeUnit=selector(x.DataTime), x.RateId })
                                                       .OrderBy(x => x.Key.RateId).Select(cl => new StackChartData(
                                                                             cl.Key.RateId,
                                                                             cl.Key.TimeUnit.ToString(CultureInfo.CurrentCulture),
                                                                             cl.Sum(c => Convert.ToDecimal(c.YData)),
                                                                             chartSetting.GetColorCode(cl.Key.RateId))).ToList();
    }
