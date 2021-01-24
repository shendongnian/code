    public class FilterCityStrategy : IFilterStrategy<City> //notice the chage here
    {
        public List<City> Filter(List<City> filterThisData, string partialCityName)
        {
            return filterThisData.Where(f => f.CityName.StartsWith(partialCityName));
        }
    }
