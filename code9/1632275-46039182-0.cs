    internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			var str = @"[{
            ""Projekt"": ""Bakker Bouw Service"",
            ""Ruimte"": ""Hoofdgebouw"",
            ""Apparaat"": {
                ""project"": ""Bosboom001"",
                ""versie"": ""812""
            },
            ""Apparaat naam"": """",
            ""Status"": ""Goedgekeurd"",
            ""Testname1"": """",
            ""Testname3"": ""2000-01-04T10:37:00+01:00"",
            ""Testname7"": ""2001-01-03T00:00:00+01:00""
        }, {
            ""Projekt"": ""Bakker Bouw Service"",
            ""Ruimte"": ""Hoofdgebouw"",
            ""Apparaat"": {
                ""project"": ""Vlaams003"",
                ""versie"": ""713""
            },
            ""Apparaat naam"": """",
            ""Status"": ""Goedgekeurd"",
            ""Testname1"": ""Slecht"",
            ""Testname7"": ""2000-01-04T10:37:00+01:00"",
            ""Testname9"": ""2001-01-03T00:00:00+01:00"",
            ""Testname16"": ""18MOhm"",
            ""Testname23"": ""OK""
        }, {
            ""Projekt"": ""Bakker Bouw Service"",
            ""Ruimte"": ""Hoofdgebouw"",
            ""Apparaat"": {
                ""project"": ""Vlaams017"",
                ""versie"": ""73""
            },
            ""Apparaat naam"": ""GDR34Z5"",
            ""Status"": ""Afgekeurd"",
            ""Testname7"": ""2000-01-04T10:37:00+01:00"",
            ""Testname10"": ""0,012mA"",
            ""Testname16"": ""200MOhm"",
            ""Testname23"": ""200MOhm"",
            ""Testname25"": ""Afgekeurd"",
            ""Testname31"": ""0,01mA""
        }
    ]";
    
    			var sw = Stopwatch.StartNew();
    
    			var result = Mapper.Map(str);
    
    
    			sw.Stop();
    			Console.WriteLine($"Deserialized at {sw.ElapsedMilliseconds} ms ({sw.ElapsedTicks} tiks)");
    		}
    
    		public static class Mapper
    		{
    			static Mapper()
    			{
    				List<string> names = new List<string>();
    				IEnumerable<PropertyInfo> p = typeof(KeuringRegel).GetProperties().Where(c => c.CanRead && c.CanWrite);
    				foreach (var propertyInfo in p)
    				{
    					var attr = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
    					names.Add(attr != null ? attr.PropertyName : propertyInfo.Name);
    				}
    
    				Properties = names.ToArray();
    			}
    
    
    			private static string[] Properties { get; }
    
    			
    
    			public static KeuringRegel[] Map(string str)
    			{
    				var keuringRegels = JsonConvert.DeserializeObject<KeuringRegel[]>(str);
    				var objs = JsonConvert.DeserializeObject(str) as IEnumerable;
    				var objectList = new List<JObject>();
    				foreach (JObject obj in objs)
    					objectList.Add(obj);
    
    				for (var i = 0; i < keuringRegels.Length; i++)
    				{
    					keuringRegels[i].testNames = new Dictionary<string, object>();
    					foreach (var p in objectList[i].Children().OfType<JProperty>().Where(c => !Properties.Contains(c.Name)).ToArray())
    						keuringRegels[i].testNames.Add(p.Name, p.Value);
    				}
    
    				return keuringRegels;
    			}
    		}
    
    
    		public class KeuringRegel
    		{
    			public string Projekt { get; set; }
    			public string Ruimte { get; set; }
    			public Apparaat Apparaat { get; set; }
    
    			[JsonProperty(PropertyName = "Apparaat naam")]
    			public string Apparaatnaam { get; set; }
    
    			public string Status { get; set; }
    			public Dictionary<string, object> testNames { get; set; }
    		}
    
    		public class Apparaat
    		{
    			public string project { get; set; }
    			public string versie { get; set; }
    		}
    	}
