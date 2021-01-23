    public class Person
    {
       public string field1 { get; set; }
       public string field2 { get; set; }
       public string field3 { get; set; }
    }
    var response = "[{\"field1\":\"Eva\",\"field2\":\"29\",\"field3\":false},{\"field1\":\"Karen\",\"field2\":\"32\",\"field3\":false}]";
    JToken json = JToken.Parse(response);
    var model = json.ToObject<List<Person>>();
