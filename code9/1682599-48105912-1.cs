    public class root
    {
    	public Tabla[] tabla { get; set; }
    }
    
    public class Tabla
    {
    	public string nombretabla { get; set; }
    	public CamposTabla campostabla { get; set; }
    	public string filtro { get; set; }
    }
    
    public class CamposTabla
    {
    	public string[] campo { get; set; }
    }
