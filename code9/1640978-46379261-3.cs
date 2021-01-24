    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    namespace JsonSerialization
    {
    	public class ResultsEntrySerializer : JsonConverter
    	{
    		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    		{
    			var entry = value as IResultsEntry;
    			if (entry == null) throw new ArgumentException("Cannot convert parameter", nameof(value));
    			writer.WriteStartObject();
    			writer.WritePropertyName(entry.Name);
    			serializer.Serialize(writer, entry.Entry);
    			writer.WriteEndObject();
    		}
    
    		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    		{
    			//TODO: I leave this up to the reader
    			throw new NotImplementedException();
    		}
    
    		public override bool CanConvert(Type objectType)
    		{
    			return objectType.GetInterfaces().Contains(typeof(IResultsEntry));
    		}
    	}
    
    	[JsonConverter(typeof(ResultsEntrySerializer))]
    	interface IResultsEntry
    	{
    		string Name { get; }
    		object Entry { get; set; }
    	}
    
    	class Info
    	{
    		public int Type { get; set; }
    		public string Message { get; set; }
    	}
    
    	class InfoEntry : IResultsEntry
    	{
    		string IResultsEntry.Name => "Info";
    
    		object IResultsEntry.Entry
    		{
    			get => Entry;
    			set => Entry = (Info)value;
    		}
    
    		public Info Entry { get; set; }
    	}
    
    	class Detail
    	{
    		public int Type { get; set; }
    		public string Something { get; set; }
    	}
    
    	class DetailEntry : IResultsEntry
    	{
    		string IResultsEntry.Name => "Error";
    
    		object IResultsEntry.Entry
    		{
    			get => Entry;
    			set => Entry = (Detail)value;
    		}
    
    		public Detail Entry { get; set; }
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var list = new List<IResultsEntry>
    			{
    				new InfoEntry
    				{
    					Entry = new Info { Type = 5, Message = "A message 1" }
    				},
    				new InfoEntry
    				{
    					Entry = new Info { Type = 6, Message = "A message 3" }
    				},
    				new InfoEntry
    				{
    					Entry = new Info { Type = 7, Message = "A message 2" }
    				},
    				new DetailEntry
    				{
    					Entry = new Detail { Type = 8, Something = "A different thing" }
    				}
    			};
    			Console.WriteLine(JsonConvert.SerializeObject(list));
    			Console.ReadLine();
    		}
    	}
    }
