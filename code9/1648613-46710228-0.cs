    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    string ar = "[{\"id\":\"1\",\"name\":\"John\"},{\"id\":\"2\",\"name\":\"Steve\"}]";
    var obj = JsonConvert.DeserializeObject(ar);
    foreach (var item in ((JArray)obj))
    {
        Console.WriteLine(
            string.Format("id:{0}, name:{1}",
                            item.Value<int>("id"),
                            item.Value<string>("name")));
    }
