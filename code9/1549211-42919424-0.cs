    public class Valores
    {
    	[JsonProperty("nome")]
    	public string Nome { get; set; }
    	[JsonProperty("valor")]
    	public double Valor { get; set; }
    	[JsonProperty("ultima_consulta")]
    	public int UltimaConsulta { get; set; }
    	[JsonProperty("fonte")]
    	public string Fonte { get; set; }
    }
    
    public class ValoresList
    {
    	public boolean status { get; set; }
    	public Valores USD { get; set; }
    	public Valores EUR { get; set; }
    	public Valores ARS { get; set; }
    	public Valores GBP { get; set; }
    	public Valores BTC { get; set; }
    }
 
