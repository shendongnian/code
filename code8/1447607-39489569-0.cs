    public interface ICar {
	    string Name { get; }
    }
    class BigCar : ICar {
	    string Name {
		    get { return "Big Car"; }
	    }
    }
    class SmallCar : ICar {
	    string Name {
		    get { return "Small Car"; }
	    }
    }
