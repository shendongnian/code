    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
    public class Car
    {
        [Key]
        public int id { get; set; }
        public string CarName { get; set; }
    	public virtual Person Person { get; set;}
    }
