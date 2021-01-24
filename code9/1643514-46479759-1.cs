        public class WorldB {
        	public Animals animals {get;set;} = new Animals();
        	public class Animals{
        		public string abc { get; set; }
        	}
        }
        WorldB b = new WorldB();
        b.animals.abc = "foo";
    If you use this method you won't be able to have the same name for the class and the property.
