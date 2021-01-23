    using System;
    using System.Text.RegularExpressions;
    
    public class Program {
    	public static void Main() {
    		string[] input = { "M3A4S0S3I2M1O4", "M3a4s0s3i2m1o4", "m3a4s0s3i2m1o4", "F3a4i0l4l1a6", "30470041106042700156", "30470031201042506146" };
    		foreach (var line in input)
    			if (Regex.IsMatch(line, @"\D"))
    				Console.WriteLine(line);
    	}
    }
