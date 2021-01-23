    public class Model
     {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
     }
    List<Model> list = new List<Model>();
    list.Add(new Model { Id = 1, Name = "Jon", SurName = "Snow"});
    var stringJson = JsonConvert.SerializeObject(list, new JsonSerializerSettings
      {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
      });
