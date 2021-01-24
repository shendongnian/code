    private List<Customer> _myCustomers = new List<Customer>();
    public class Customer
    {
        /// <summary>  
        /// Name of customer  
        /// </summary>  
        public string Name { get; set; }
        /// <summary>  
        /// Sex of customer  
        /// </summary>  
        public bool Sex { get; set; }
        /// <summary>  
        /// List of favourite foods
        /// </summary>  
        public List<FavouriteFood> FavouriteFoods { get; set; }
    }
    public class FavouriteFood {
        public FavouriteFood() { }
        public FavouriteFood(string _food) { this.Food = _food; }
        public string Food { get; set; }
    }
