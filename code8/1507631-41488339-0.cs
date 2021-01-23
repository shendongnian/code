    public class Project
    {
        public string date_closed { get; set;}
    }
    public class MyClass
    {
        public Project project { get; set;}
    }
    var obj = new MyClass();
    obj.project = new Project();
    obj.project.date_closed = DateTime.Now.ToString("yyyy-MM-dd");
    var instructionString = JsonConvert.SerializeObject(obj);
