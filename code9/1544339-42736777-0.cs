	using System;
	using Newtonsoft.Json;
	namespace com.example.SO42736347
	{
		public class Action
		{
			public string Type { get; set; }
		}
		public class Action1 : Action
		{
			public string Data { get; set; }
		}
		
		public class Program
		{
		
			public const string ACTION1 = @"{
			    ""Type"" : ""com.example.Json.Action1"",
				""Data"" : ""41°24'12.2 N 2°10'26.5""
			}";
		
			public static void Main()
			{
				var action = JsonConvert.DeserializeObject<Action>(ACTION1);
				
				var type = Type.GetType(action.Type);
				var action1 = (Action1) JsonConvert.DeserializeObject(ACTION1, type);
			}
			
		}
	}
