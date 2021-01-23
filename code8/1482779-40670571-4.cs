    public class MyClass {
        private readonly IContext context;
    
        public MyClass(IContext context) {
            this.context = context;
        }
    
        public Toys[] Get() {
            return context.Toys.ToArray();
        }
        public void Add(ToyModel model) {
            var toy = new Toy { Id = model.Id, Name = model.Name };
            context.Toys.Add(toy);
            context.SaveChanges();
        }
    }
