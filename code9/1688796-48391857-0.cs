    interface IFilter
    {
    }
    class CountryFilter 
    {
    	string PartialCountryName { get; set;}
    }
    
    class CityFilter 
    {
    	string CountryCode { get; set;}
    	string PartialCityName { get; set;}
    }
    
    
    interface IFilterStrategy<T,U> where U:IFilter
    {
    	List<T> Filter(List<T> source,U filter);
    }
    class CountryFilterStategy : IFilterStrategy<Country,CountryFilter>
    {
    	List<Country> Filter(List<Country> source,CountryFilter filter)
    	{
    		//logic
    	}
    }
    
    class CityFilterStategy : IFilterStrategy<City,CityFilter>
    {
    	List<City> Filter(List<City> source,CityFilter filter)
    	{
    		//logic
    	}
    }
