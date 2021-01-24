    public static class CalculationDataExtensions
    {
      public static IEnumerable<double> CalcRSquared(
        this IEnumerable<CalculationData> source,
        Func<CalculationData, decimal> propertySelector)
      {
        IEnumerable<double> values = source
          .Select(propertySelector)
          .Select(x => (double)x);
    
        return GoodnessOfFit.RSquared(values);
      }
    }
