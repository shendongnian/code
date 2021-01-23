    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var january = new Month("January");
    	
    		january.Measurements.Add(new Measurement { Day = "Day1", Temperature = 22 });
    		january.Measurements.Add(new Measurement { Day = "Day2", Temperature = 25 });
    		january.Measurements.Add(new Measurement { Day = "Day3", Temperature = 26 });
    		january.Measurements.Add(new Measurement { Day = "Day4", Temperature = 18 });
    		january.Measurements.Add(new Measurement { Day = "Day5", Temperature = 16 });
    		january.Measurements.Add(new Measurement { Day = "Day6", Temperature = 17 });
    		
    		// finding months by their name
    		// using a dictionary will perform this lookup in O(1)
    		var months = new Dictionary<string, Month>();
    		months.Add(january.Name, january);
    		
    		var selectedValue = "January"; // DropDownList1.SelectedValue.ToString();
    		if (months.ContainsKey(selectedValue)) {
    			var selectedMonth = months[selectedValue];
                // all the knowledge about the month is encapsulated
    			var maxTemp = selectedMonth.Max.Temperature;
    			var maxDay = selectedMonth.Max.Day;
    			var averageTemp = selectedMonth.Average;
    			Console.WriteLine(selectedMonth.Name + ": Max " + maxTemp + " (on " + maxDay +") Avg " + string.Format("{0:0.00}", averageTemp));
    			
    		}
    		else {
    			throw new ArgumentException("Key not found: " + selectedValue);
    		}
    		
    	}
    	
        // groups measurements for a certain month and does calculations
    	public class Month {
    		
    		public Month(string name) {
    			Name = name;
    			Measurements = new List<Measurement>();
    		}
    		
    		public string Name { get; private set; }
    		
    		public ICollection<Measurement> Measurements { get; private set;}
    		
    		public double Average { get { return Measurements.Average(r => r.Temperature); } }
    		
    		// LINQ .Min() and .Max() would only return int
    		// sorting will allow you to return the full Measurement, including the day
            // runs in O(log(n)), see http://stackoverflow.com/q/3188693/1450855
    		public Measurement Min { get { return Measurements.OrderBy(m => m.Temperature).First(); } }
    		public Measurement Max { get { return Measurements.OrderBy(m => m.Temperature).Last(); } }
    		
    	}
    	
        // single data point
    	public class Measurement {
    		public string Day { get; set; }
    		public int Temperature { get; set; }
    	}
    }
