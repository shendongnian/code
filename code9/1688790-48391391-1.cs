    public class FilterCityStrategy : IFilterStrategy<City>
    {
        public List<City> Filter<City>(List<City> filterThisData, string partialCityName)
        {
            return filterThisData.Where(f => f.CityName.StartsWith(partialCityName));
        }
    }
