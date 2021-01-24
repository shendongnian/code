    using System;
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    [JsonObject(ItemRequired = Required.Always)]
    public class ItemA
    {
        [JsonIgnore]
        [JsonProperty(Required = Required.Default)]
        public new Guid Id { get; set; } //hiding Guid Id Common
        public Folder ParentFolder { get; set; }
        //...
    }
    public class Folder
    {
        public string Id { get; set; }
    
        public string Path { get; set; }
    }
    
    public class ItemB
    {
        //...
        public List<Folder> Folders { get; set; } = new List<Folder>();
        public List<ItemA> ItemAs { get; set; } = new List<ItemA>();
    }
    public class Test
    {
   
        var jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
       //ItemB b = new ItemB()
        //{
        //    Folders = new List<Folder>() {
        //        new Folder() { Id = "1", Path = "myPath1" },
        //        new Folder() { Id = "2", Path = "myPath2" },
        //        new Folder() { Id = "3", Path = "myPath3" } },
        //    ItemAs = new List<ItemA>() {
        //        new ItemA() { Id = Guid.NewGuid(), ParentFolder = new Folder()
        //        { Id = "p1", Path = "parentpath1" } },
        //new ItemA()
        //{ Id = Guid.NewGuid(),
        //    ParentFolder = new Folder()
        //{ Id = "p2", Path = "parentpath2" } }}
        //};
        //string json = JsonConvert.SerializeObject(b);
        string json = "{\"Folders\":[{\"Id\":\"1\",\"Path\":\"myPath1\"},{\"Id\":\"2\",\"Path\":\"myPath2\"},{\"Id\":\"3\",\"Path\":\"myPath3\"}],\"ItemAs\":[{\"Id\":\"RgAAAAAD01CCe0GCRpDdKTQq2OCQBwAIuTruAfDrRZi9RPZnww3OAAAAAAEMAAAIuTruAfDrRZi9RPZnww3OAABE1hqaAAAA\",\"ParentFolder\":{\"Id\":\"p1\",\"Path\":\"parentpath1\"}},{\"Id\":\"c0af33a9-3e6f-4405-a2d4-ff469cb67fce\",\"ParentFolder\":{\"Id\":\"p2\",\"Path\":\"parentpath2\"}}]}";
        dynamic d = JsonConvert.DeserializeObject<ItemB>(json, jsonSettings);
        //no serialization error 
        ((ItemB)d).ItemAs.ForEach(x => x.Id = Guid.NewGuid());
       
    }
