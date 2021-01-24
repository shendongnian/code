    public class DailyStack : IStackChartData
    {
        public IReadOnlyCollection<StackChartData> GetDetails(StackChartSetting chartSetting)
        {
            return MyUtilities.GetDetails(chartSetting, x => x.Hour);
        }
    }
    
    public class MonthlyStack : IStackChartData
    {
        public IReadOnlyCollection<StackChartData> GetDetails(StackChartSetting chartSetting)
        {
            return MyUtilities.GetDetails(chartSetting, x => x.Date);
        }
    }
    
    public class YearlyStack : IStackChartData
    {
        public IReadOnlyCollection<StackChartData> GetDetails(StackChartSetting chartSetting)
        {
            return MyUtilities.GetDetails(chartSetting, x => x.Month);
        }
    }
