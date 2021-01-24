    public class Dish
    {
        public Dish(int cost, string name)
        {
            Cost = cost;
            Name = name;
        }
    
        public int Cost { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}: {Cost.ToString("c")}"; 
        }
    }
