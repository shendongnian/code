        static void Main(string[] args)
        {
            var myJsonInput = @"{'Id':'123','Name':'abc'}";
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var interimObject = JsonConvert.DeserializeObject<ExpandoObject>(myJsonInput);
            var myJsonOutput = JsonConvert.SerializeObject(interimObject, jsonSerializerSettings);
            Console.Write(myJsonOutput);
            Console.ReadKey();
        }
