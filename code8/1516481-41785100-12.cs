    public class Program {
    	public static void Main() {
            // creating measurements
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
                // do calculations for the selected month
                // how the calculations are performed is encapsulated
    			var max = selectedMonth.MaxByTemp;
    			string averageTemp = string.Format("{0:0.00}", selectedMonth.Average);
    			
                // Label1.Text = string.Format(
                Console.WriteLine(selectedMonth.Name + ": Max " + max.Temperature + 
                    " (on " + max.Day + ") Avg " +  averageTemp);
    		}
    		else {
    			throw new ArgumentException("Month not found: " + selectedValue);
    		}
    	}
    }
    	
        
