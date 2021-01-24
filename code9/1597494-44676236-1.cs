	namespace ConsoleApp3
	{
		class Program
		{
			static void Main(string[] args)
			{
				var jsonfile = File.ReadAllText("jsonfile.json");
				var deserializedFile = JsonConvert.DeserializeObject<Domain.RootObject>(jsonfile);
                // Do something with your object
			}
		}
	}
