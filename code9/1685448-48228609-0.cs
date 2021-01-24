    public class Template
    {
    	public TemplateTypeEnum TemplateType { get; set; }
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    public enum TemplateTypeEnum
    {
    	FirstItem = 1,
    	SecondItem = 2,
    }
