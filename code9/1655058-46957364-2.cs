    public class SelectModel
    {
        public List<String> Scripts { get; set; }
        public string ScriptSelection { get; set; }
        public IFormFile InputFile { get; set; }
    
        public SelectModel()
        {
          this.Scripts =new List<string>();
        } 
    
    }
