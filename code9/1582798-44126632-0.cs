    using System;
						
	public class Program
	{
		public static void Main()
		{
			string hostName = "B1";
			string[] buildingCode = {"B1","B2","B3","B4"};
			string[] buildingName = {"Building 1", "Building 2", "Building 3", "Building 4"};
			
			if (Array.Exists(buildingCode, element => element == hostName))
			{
				 Console.Write(buildingName[Array.IndexOf(buildingCode, hostName)]);
			}
			else
			{
				 Console.Write("Error!");
			}
		}
	}
