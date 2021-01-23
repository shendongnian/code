	public class CarModel {
		public string Name { get; set; }
	}
	
	public class Toyota : CarModel {
		public string SpecialToyotaNumber { get; set; }
	}
	
	public class Honda : CarModel { }
	
	public interface ICar {
		CarModel Property { get; set; }
		CarModel Method();
	}
	
	public class Car<T> : ICar where T : CarModel {
		public T Property { get; set; }
	
		public T Method() {
			return (T)new CarModel();
		}
	}
	
	public class Main {
		public void Run() {
			ICar car = new Car<Toyota>();
			car.Property = new Honda(); // the concrete property is declared Toyota
		}
	}
