    public class Fruit
    {
        protected string[] GroupFruit { get; set; }
        public Fruit()
        {
        }
    }
    public class Citrus : Fruit
    {
        public Citrus()
        {
            base.GroupFruit = new string[] {"lemon", "lime", "orange"};
        }
    }
