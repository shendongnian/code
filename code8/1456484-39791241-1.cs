	public class Animal {
		public Animal() {
			animalType = new List<AnimalType>();
		}
		
		public string animalDesc { get; set; }
		public List<AnimalType> animalType { get; set; }
	}
	
	public class AnimalType {
		public string typeDesc { get; set; }	
	}
