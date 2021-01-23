    public class Menu
    {
        public Menu()
        {
            Children = new HashSet<Menu>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Parent { get; set; }
        public ICollection<Menu> Children { get; private set; }
    }
