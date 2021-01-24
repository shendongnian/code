    using System;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			var inputs = new string[] 
            {
                "77715926535897932384626433832795",
                "8",
                "2398798734",
                "0092",
                "12987981239871928379817231",
                "98279384792873498274908123946109478276492874927864928734872983476928739487298374"
            };
            //Determine the length of the longest number when expressed as a string
			var maxLength = inputs.Select(a => a.Length).Max();
            //Pad all the numbers to the left with zeroes
			var padded = inputs.Select(a => a.PadLeft(maxLength, '0'));
            //Now sort them
			var sorted = padded.OrderBy(a => a);
			foreach (var s in sorted)
			{
				Console.WriteLine(s);
			}
		}
	}
