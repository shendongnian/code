    // ...
    var settings = new JsonSerializerSettings { 
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    };
    var json = JsonConvert.SerializeObject(project, settings);
    var projectFromJson = JsonConvert.DeserializeObject<Project>(json);
    Console.WriteLine(ReferenceEquals(projectFromJson.Templates[1],
        projectFromJson.Tasks.First().Template));
    // This outputs "True"
