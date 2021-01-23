    using System.Collections.Generic;
    using System.Linq;
    // groups measurements for a certain month and does calculations for this month
    public class Month {
    		
    	public Month(string name) {
    		Name = name;
    		Measurements = new List<Measurement>();
    	}
    		
        // dictionary key
    	public string Name { get; private set; }
    		
        // note that the outside only knows we use an ICollection,
        // that we actually use a List in our implementation is hidden from them
    	public ICollection<Measurement> Measurements { get; private set;}
  
        // to answer your original question:
    	// LINQ .Min(m => m.Temperature) and .Max() would only return int
    	// sorting will allow you to return the full Measurement, including the day
        // OrderBy runs in O(log(n)), see http://stackoverflow.com/q/3188693/1450855
    	public Measurement MinByTemp { get { 
            return Measurements.OrderBy(m => m.Temperature).First(); 
        } }
    	public Measurement MaxByTemp { get { 
            return Measurements.OrderBy(m => m.Temperature).Last(); 
        } }
       // more LINQ goodness
       // beware: all these getters cause recalculation each time they are called!
       // on the plus side, the results are always up to date
       public double Average { get { return Measurements.Average(r => r.Temperature); } }	
    }
