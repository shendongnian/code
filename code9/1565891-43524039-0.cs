    using System;
	using System.Collections.Generic;
	using System.Linq;
						
	public class Program
	{
		public static void Main()
		{
			string address1 = "Address1";
			string address2 = "Address2";
			string city = "City";
			string country = "Country";
			string postalCode = "00000";
			
			List<string> strArray = new List<string> { address1, address2, city, country, postalCode };
			
			string fullAddress = string.Join(",", strArray.Where(m=> !string.IsNullOrEmpty(m)).ToList());
			
			Console.WriteLine(fullAddress);
		}
	}
