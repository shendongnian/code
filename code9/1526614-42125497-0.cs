    public class RestaurantVM
    {
        public string Title { get; set; }
        public string City { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
