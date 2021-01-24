    public class ErrorDetails
    {
        public int Id { get; set; }
        public string ErrorMessage { get; set; }
    }
    var json = "{'Id': 1,'error_message': 'An error has occurred!'}";
    var dezerializerSettings = new JsonSerializerSettings
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };
    var obj = JsonConvert.DeserializeObject<ErrorDetails>(json, dezerializerSettings);
    var jsonNew = JsonConvert.SerializeObject(obj);
