    public class ToyModel {
        private readonly IContext context;
    
        public MyClass(IContext context) {
            this.context = context;
        }
    
        public Toys[] Get() {
            return context.Toys.ToArray();
        }
        public void Create(Toy toy) {
            context.Toys.Add(toy);
            context.SaveChanges();
        }
    }
