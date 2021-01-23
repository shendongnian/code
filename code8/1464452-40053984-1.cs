    public class Course
    {
        public string CourseName { get; set; }
        public List<Dish> Dishes { get; set; }
    }
    
    public class Dish
    {
        public string DishName { get; set; }
        public decimal Price { get; set; }
    }
