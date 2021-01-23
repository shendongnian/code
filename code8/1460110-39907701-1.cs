   	using System.IO;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Json;
	using System.Text;
	namespace ConsoleApplication1
	{
		class Program
		{
			const string Json = @"{""data"":{""id"":12343281337970,""name"":""Eric Legault"",""email"":""eric@foo.com"",""photo"":null,""workspaces"":[{""id"":1234250096894,""name"":""foo""},{""id"":123446170860,""name"":""Personal Projects""},{""id"":12345000597911,""name"":""foo2""}]}}";
			static void Main(string[] args)
			{
				var theReturn = DeserializeJson(Json);
			}
			private static  AsanaObjects DeserializeJson(string json) {
				var jsonSerializer = new DataContractJsonSerializer(typeof(AsanaObjects));
				var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
				return jsonSerializer.ReadObject(stream) as AsanaObjects;
			}
			public partial class AsanaObjects
			{
				[DataContract]
				public class Workspace
				{
					[DataMember]
					public object id { get; set; }
					[DataMember]
					public string name { get; set; }
				}
			}
			public partial class AsanaObjects
			{
				[DataContract]
				public class Data2
				{
					[DataMember]
					public long id { get; set; }
					[DataMember]
					public string name { get; set; }
					[DataMember]
					public string email { get; set; }
					[DataMember]
					public object photo { get; set; }
					[DataMember]
					public Workspace[] workspaces { get; set; }
				}
			}
			[DataContract]
			public partial class AsanaObjects
			{
				[DataMember]
				public Data2 data { get; set; }
			}
		}
	}
