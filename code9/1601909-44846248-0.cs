	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
						
	public class Root
	{
		public int Offset { get; set; }
		public List<Dictionary<string, string>> Records { get; set; }
	}
	
	public class Program
	{
		public static void Main()
		{
			var asDictionary = JsonConvert.DeserializeObject<Root>(@"{
			
			offset: 20,
			records:[
				{
					key1: ""value 1"",
					key2: ""value 2"",
					key3: ""value 3""
				},
				{
					key1: ""value 4"",
					key2: ""value 5"",
					key3: ""value 6""
				}			
			]}");
			
			Console.WriteLine("Offset: {0}", asDictionary.Offset);
			foreach( var record in asDictionary.Records )
			{
				Console.WriteLine("-----");
				foreach(var pair in record)
				{
					Console.WriteLine("{0} = {1}", pair.Key, pair.Value);
				}
			}
		}
	}
