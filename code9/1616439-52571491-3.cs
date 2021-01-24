    internal class Program
    {
        private static void Main(string[] args)
        {
            var json = File.ReadAllText("data.json");
            JObject jObject = JObject.Parse(json);
            AutoMapperConfiguration.Configure();
            var result = AutoMapper.Mapper.Map<EmployeeDTO>(jObject);
        }
    }
