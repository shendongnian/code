    [Serializable]
    public class Model {
    	public string List<City> cities = new List<City>();
    }
    
    [Serializable]
    public class City {
    	public string name;
    	public int population;
    	public List<Person> people;
    }
    
    [Serializable]
    public class Person {
    	public string name;
    	public int age;
    }
