    public class RetrievedClass
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string events { get; set; }
    }
    List<RetrievedClass> dbData = mssql()
    List<YourClass> result = dbData.Select(x => new YourClass
        {
            firstname = x.firstname,
            lastname = x.lastname,
            events = Newtonsoft.Json.JsonConvert.DeserializeObject(x.events)
        });
