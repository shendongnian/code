    public interface ICarFactory {
	    ICar CreateCar();
    }
    public class BigCarFactory : ICarFactory {
	    ICar CreateCar() { return new BigCar (); }
    }
    public class SmallCarFactory : ICarFactory {
	    ICar CreateCar() { return new SmallCar (); }
    }
