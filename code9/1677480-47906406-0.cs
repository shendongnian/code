    public class Template 
    {
        public int Id { get; set; }
        public TemplateVersion CurrentVersion { get; set; }
    }
    
    public class TemplateVersion
    {
        public int Id { get; set; }
        public Template Template { get; set; }
    }
