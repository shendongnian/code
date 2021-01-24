    public class FilterCityStrategy : IFilterStrategy<City>
    {
        public List<City> Filter(List<City> filterThisData, string partialCityName)
        {
          return filterThisData.Where(f => f.CityName.StartsWith(partialCityName)).ToList<City>();
        }
    }
