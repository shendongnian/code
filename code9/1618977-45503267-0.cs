    public class Country
    {
       private List<City> cities = null;
       public List<City> Cities
       {
     
          get
            {
                if(cities == null)
                     cities = new List<City>();
               return cities;
            }
         set
           {
               cities = value;
           }
       } 
    }
