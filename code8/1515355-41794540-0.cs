    public class House
    {
    	public int Id { get; set; }
    	public Garage Garage { get; set; }
    	public string Style { get; set; }
    }
    
    public class Garage
    {
    	public int Id { get; set; }
    	public House House { get; set; }
    	public int Size { get; set; }
    }
