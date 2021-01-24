    Asp.Net Core Web Api
    [ModelMetadataType(typeof(IPerson))]
    public partial class Person : IPerson
    {
    }
    public partial class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public interface IPerson
    {
        [JsonIgnore]
        string Name { get; set; }
    }
