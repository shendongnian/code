	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using System.Linq;
						
	public class Program
	{
		static string fakeJsonString = 
			@"{ ""text"": ""This is a text"", ""intValue"": 10, ""dictionary"": { ""key"": ""value"" }, ""array"": [ 10, 20, 30 ] }";
			
		
		internal class FakeObject {
			[JsonProperty("text")]
			public string Text { get;set; }
			[JsonProperty("intValue")]
			public int IntValue { get;set; }
			[JsonProperty("dictionary")]
			public Dictionary<string, string> Dictionary { get;set; }
			[JsonProperty("array")]
			public int[] IntArray { get;set; }
		}
		
		public static void Main()
		{
			var fakeObject = JsonConvert.DeserializeObject<FakeObject>( fakeJsonString );
			Console.WriteLine("Current value for text: "  + fakeObject.Text);
			Console.WriteLine("Current value for intValue: "  + fakeObject.IntValue);
			Console.WriteLine("Current value for Dictionary: "  + string.Join( ",", fakeObject.Dictionary.Select(kvp => "\"" + kvp.Key + "\": \"" + kvp.Value + "\"" ) ) );
			Console.WriteLine("Current value for IntArray: "  + string.Join( ",", fakeObject.IntArray));
		}
	}
