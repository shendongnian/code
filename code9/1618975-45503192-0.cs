    public class Country
    {
        public virtual IEnumerable<City> Cities { get; set; } = new List<City>();
        // ...
    }
