    public class BmwController : Controller
    {
        public ICarFactory carFactory;
        public BmwController(ICarFactory carFactory)
        {
            this.carFactory = carFactory;
            // Get the car
            ICar bmw = carFactory.Create("Bmw");
        }
    }
