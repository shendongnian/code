    // groups measurements for a certain month and does calculations
    public class Month {
    		
    	public Month(string name) {
    		Name = name;
    		Measurements = new List<Measurement>();
    	}
    		
        // dictionary key
    	public string Name { get; private set; }
    		
        // note that the outside only knows we use an ICollection,
        // that we actually use a List is hidden from them
    	public ICollection<Measurement> Measurements { get; private set;}
  
        // to answer your original question:
    	// LINQ .Min() and .Max() would only return int
    	// sorting will allow you to return the full Measurement, including the day
        // runs in O(log(n)), see http://stackoverflow.com/q/3188693/1450855
    	public Measurement Min { get { return Measurements.OrderBy(m => m.Temperature).First(); } }
    	public Measurement Max { get { return Measurements.OrderBy(m => m.Temperature).Last(); } }
       // more LINQ goodness
       public double Average { get { return Measurements.Average(r => r.Temperature); } }
    		
    }
